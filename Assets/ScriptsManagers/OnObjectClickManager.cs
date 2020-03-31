using Decorations.Scripts;
using UnityEngine;

namespace ScriptsManagers
{
    public class OnObjectClickManager : MonoBehaviour
    {
        public LayerMask whatIsOnBoardItem;
        private Camera _camera;
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (GameManager.Main.gameState != GameState.InGame)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                if (GameManager.Main.gameState != GameState.InGame)
                    return;

                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hitInfo, float.PositiveInfinity, whatIsOnBoardItem) == false)
                    return;

                hitInfo.collider.TryGetComponent(out ItemInfoHolder result);
                result.DisplayItemInfo();
            }
        }
    }
}
