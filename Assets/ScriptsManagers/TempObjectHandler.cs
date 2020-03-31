using System.Collections.Generic;
using Decorations.Scripts;
using Grid.Scripts;
using UnityEngine;

namespace ScriptsManagers
{
    public class TempObjectHandler : MonoBehaviour
    {
        private List<GridElement> _cellsInRange = new List<GridElement>();

        private MaterialHandler _materialHandler;
        private void Start()
        {
            _materialHandler = gameObject.GetComponent<MaterialHandler>();
        }

        private void Update()
        {
            foreach (var cell in _cellsInRange)
            {
                if (cell.isOccupied)
                {
                    cell.SetMaterial(GridMaterialType.Red);
                    _materialHandler.SetPlacementMaterial(TempObjectMaterialType.Red);
                }
                else
                {
                    cell.SetMaterial(GridMaterialType.Green);
                    _materialHandler.SetPlacementMaterial(TempObjectMaterialType.Green);
                }
            }
        }

        public void MarkCellsAsOccupied()
        {
            foreach (var cell in _cellsInRange)
            {
                cell.isOccupied = true;
            }
        }

        public int GetCellCount()
        {
            return _cellsInRange.Count;
        }

        public bool CanPlaceHere()
        {
            foreach (var cell in _cellsInRange)
            {
                if (cell.isOccupied)
                {
                    return false;
                }
            }
            return true;
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Cell") == false)
                return;
        
            _cellsInRange.Add(other.gameObject.GetComponent<GridElement>());

        }
        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Cell") == false)
                return;

            var gridElement = other.gameObject.GetComponent<GridElement>();
            gridElement.SetMaterial(GridMaterialType.Default);
            _cellsInRange.Remove(gridElement);
        }

        private void OnDestroy()
        {
            foreach (var cell in _cellsInRange)
            {
                cell.SetMaterial(GridMaterialType.Default);
            }
        }
    }
}
