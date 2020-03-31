using System.Collections.Generic;
using UnityEngine;

namespace ScriptsManagers
{
    public class GridManager : MonoBehaviour
    {
        public static GridManager Main { get; private set; }
    
        public GameObject gridElement;
        public GameObject gridHolder;
        public int columns;
        public int rows;
        public float gridSize;
        public GameObject gridAnchor;
    
        public Vector3 lowerGridAnchor { get; private set; }
        public Vector3 upperGridAnchor { get; private set; }

        private Vector3 _gridCenter;
        [SerializeField] private List<Vector3> gridElementPositionList = new List<Vector3>();

        private void Awake()
        {
            if (Main == null)
            {Main = this;}
            else
            {Destroy(this);}
        }
        private void Start()
        {
            _gridCenter = new Vector3(-columns/2, 0, rows/2);
            PlaceGrid();
            ConfigureAnchors();
       
        }

        private void PlaceGrid()
        {
            for (int i = 0; i < columns * rows; i++)
            {
                var position = new Vector3(_gridCenter.x + gridSize * (i % columns), 0, _gridCenter.z - gridSize * (i / columns));
                Instantiate(gridElement, position, Quaternion.Euler(new Vector3(90,0,0)), gridHolder.transform);
            
                gridElementPositionList.Add(position);
            }
        }

        private void ConfigureAnchors()
        {
            lowerGridAnchor = _gridCenter + new Vector3(columns*gridSize, 0 , gridSize);
            upperGridAnchor = _gridCenter + new Vector3(-gridSize, 0 , -rows * gridSize);
        
            //Debug
            Instantiate(gridAnchor, lowerGridAnchor, Quaternion.identity);
            Instantiate(gridAnchor, upperGridAnchor, Quaternion.identity);
        }
        public bool WithinGridRect(Vector3 point)
        {
            if (  point.x < lowerGridAnchor.x
                  && point.z < lowerGridAnchor.z
                  && point.x > upperGridAnchor.x
                  && point.z > upperGridAnchor.z)
            {
                return true;
            }
            return false;
        }
    }
}
