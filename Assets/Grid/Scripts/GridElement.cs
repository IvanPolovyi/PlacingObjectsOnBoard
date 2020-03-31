using UnityEngine;

namespace Grid.Scripts
{
    public class GridElement : MonoBehaviour
    {
        public Material defaultMaterial;
        public Material grinMaterial;
        public Material redMaterial;
        private MeshRenderer _meshRenderer;
        public bool isOccupied { get; set; }

        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.material = defaultMaterial;
        }
    
        public void SetMaterial(GridMaterialType gridMaterialType)
        {
            switch (gridMaterialType) 
            {
                case GridMaterialType.Default:
                    _meshRenderer.material = defaultMaterial; break;
                case GridMaterialType.Green:
                    _meshRenderer.material = grinMaterial; break;
                case GridMaterialType.Red:
                    _meshRenderer.material = redMaterial; break;
            }
        }
    }
    public enum GridMaterialType
    {
        Default,
        Green,
        Red
    }
}