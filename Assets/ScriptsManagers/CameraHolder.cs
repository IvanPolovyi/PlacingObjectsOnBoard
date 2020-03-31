using System;
using UnityEngine;

namespace ScriptsManagers
{
    public class CameraHolder : MonoBehaviour
    {
        public float movementTime;
        public LayerMask whatIsGround;

        private Vector3 _newPosition;
    
        private Camera _camera;

        private Vector3 _startDragPosition;
        private Vector3 _currentDragPosition;

        public Vector3 cameraMaxBorders;
        public Vector3 cameraMinBorders;
    
    
        private void Awake()
        {
            if (_camera == null) _camera = Camera.main;
        }


        private void Update()
        {
            if(GameManager.Main.gameState != GameState.InGame)
                return;
        
            Move();
            Zoom();
        }
    

        private void Move()
        {
            if(Input.touchCount > 1)
                return;
        
            Vector3 nextPosition = transform.position;
        
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var entry,float.PositiveInfinity, whatIsGround))
                {
                    _startDragPosition = entry.point;
                }
            }

            if (Input.GetMouseButton(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var entry, float.PositiveInfinity, whatIsGround))
                {
                    _currentDragPosition = entry.point;
                    nextPosition += _startDragPosition - _currentDragPosition;
                }
            }
            var nexPosition = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * movementTime);
            transform.position = ClampMovement(nexPosition);
        }

        private Vector3 ClampMovement(Vector3 position)
        {
            return new Vector3(Mathf.Clamp(position.x, cameraMinBorders.x, cameraMaxBorders.x),
                Mathf.Clamp(position.y, cameraMinBorders.y, cameraMaxBorders.y),
                Mathf.Clamp(position.z, cameraMinBorders.z, cameraMaxBorders.z));
        }
    
        private void Zoom()
        {
            if (Input.touchCount >= 2)
            {
                Vector3 firstTouchPosition = FromScreenToWorldPos(Input.GetTouch(0).position);
                Vector3 secondTouchPosition = FromScreenToWorldPos(Input.GetTouch(1).position);
                Vector3 firstStartPosition = FromScreenToWorldPos(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
                Vector3 secondStartPosition = FromScreenToWorldPos(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

                Vector3 anchor = (secondTouchPosition + firstTouchPosition) / 2;

                float zoom = Vector3.Distance(firstTouchPosition, secondTouchPosition) /
                             Vector3.Distance(firstStartPosition, secondStartPosition);
                if (Math.Abs(zoom) > 0.001)
                {
                    _camera.transform.position =
                        Vector3.LerpUnclamped(anchor, _camera.transform.position, 1 / zoom);
                }

            }
        }
        private Vector3 FromScreenToWorldPos(Vector2 screenPosition)
        {
            Ray ray = _camera.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out var hitInfo, float.PositiveInfinity, whatIsGround))
            {
                return ray.GetPoint(hitInfo.distance);
            }

            return Vector3.zero;
        }
    }
}
