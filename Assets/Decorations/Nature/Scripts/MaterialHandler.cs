using UnityEngine;

namespace Decorations.Scripts
{
    public class MaterialHandler : MonoBehaviour
    {
        [SerializeField]
        private Material greenPlacementMat;
        [SerializeField]
        private Material redPlacementMat;
        
        private MeshRenderer _meshRenderer;
        private Material _defaultMaterial;
        private void Awake()
        {
            _meshRenderer = gameObject.GetComponent<MeshRenderer>();
            _defaultMaterial = _meshRenderer.material;
        }
        public void SetPlacementMaterial(TempObjectMaterialType materialType)
        {
            switch (materialType) 
            {
                case TempObjectMaterialType.Default:
                    _meshRenderer.material = _defaultMaterial; break;
                case TempObjectMaterialType.Green:
                    _meshRenderer.material = greenPlacementMat; break;
                case TempObjectMaterialType.Red:
                    _meshRenderer.material = redPlacementMat; break;
            }
        }
    }
        public enum TempObjectMaterialType
        {
            Red,
            Green,
            Default
        }
}
