using UnityEngine;

namespace ScriptsManagers
{
    public class DecorationsManager : MonoBehaviour
    {
        public Transform lowerAnchor;
        public Transform upperAnchor;
    
        public GameObject decorationsHolder; public int objectsNumber = 100;
    
        public GameObject[] decorations;
        private void Start()
        {
            for (int i = 0; i < objectsNumber; i++)
            {
                var lowerPosition = lowerAnchor.position;
                var upperPosition = upperAnchor.position;

                var x = Random.Range(lowerPosition.x, upperPosition.x);
                var z = Random.Range(lowerPosition.z, upperPosition.z);

                if (!GridManager.Main.WithinGridRect(new Vector3(x, 0, z)))
                {
                    Instantiate(decorations[Random.Range(0, decorations.Length)],
                        new Vector3(x, 0, z),
                        Quaternion.Euler(new Vector3(0, Random.Range(0, 350), 0)), decorationsHolder.transform);
                }
            } 
        }


    }
}
