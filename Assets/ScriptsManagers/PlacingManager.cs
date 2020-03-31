using System.Collections;
using Decorations.Scripts;
using ItemPool.Scripts;
using UnityEngine;

namespace ScriptsManagers
{
    public class PlacingManager : MonoBehaviour
    { 
        public static PlacingManager Main { get; private set; }

        public GameObject onGridObjectHolder;
        public LayerMask whatIsGrid;
        public AudioClip startPlacingAudio;
        public AudioClip endPlacingAudio;
        
        private Camera _camera;
        private Coroutine  _placingRoutine;
        private GameObject _tempObject;

        private void Awake()
        {
            if (Main == null)
            {Main = this;}
            else
            {Destroy(this);}    
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        public void StartPlacingObject(ItemObject tempItem)
        {
            GameManager.Main.gameState = GameState.InPlacement;

            _tempObject = Instantiate(tempItem.prefab, Vector3.zero, Quaternion.identity, onGridObjectHolder.transform);
            _tempObject.AddComponent<TempObjectHandler>();
        
            Rigidbody tempRigidbody = _tempObject.AddComponent<Rigidbody>();
            tempRigidbody.isKinematic = true;
            _tempObject.tag = "Temporary";
        
            _placingRoutine = StartCoroutine(PlacementProcess(_tempObject));
            LeanAudio.play(startPlacingAudio, 0.5f);
        }

        public void StopObjectPlacement(ItemObject tempItem)
        {        
            StopCoroutine(_placingRoutine);
            PlaceItem(tempItem);
        }
    
        private IEnumerator PlacementProcess(GameObject tempObject)
        {
            while (true)
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hitInfo, float.PositiveInfinity, whatIsGrid))
                {
                    tempObject.transform.position = hitInfo.transform.position;
                }
                yield return new WaitForEndOfFrame();
            }
        }
        
        public void PlaceItem(ItemObject item)    
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitCell, float.PositiveInfinity, whatIsGrid) == false)
            {
                Destroy(_tempObject);
                return;
            }

            if (_tempObject.GetComponent<TempObjectHandler>().CanPlaceHere() == false)
            {
                Destroy(_tempObject);
                return;
            }
        
            TempObjectHandler tempObjectHandler = _tempObject.GetComponent<TempObjectHandler>();
            tempObjectHandler.MarkCellsAsOccupied();
        
            GameObject newObject = Instantiate(item.prefab, hitCell.transform.position, Quaternion.identity, transform);
            Rigidbody newObjectRb = newObject.AddComponent<Rigidbody>();
            newObjectRb.isKinematic = true;
            
            GameData.Main.spawnedItems.Add(item);
            ItemInfoHolder newObjectInfo = newObject.GetComponent<ItemInfoHolder>();

            newObjectInfo.itemObject = item;
            newObjectInfo.id = GameData.Main.spawnedItems.Count - 1;
            newObjectInfo.itemObject.sizeOnGrid = tempObjectHandler.GetCellCount();
        
            LeanAudio.play(endPlacingAudio, 0.5f);
            Destroy(_tempObject);
        }
    
    }
}