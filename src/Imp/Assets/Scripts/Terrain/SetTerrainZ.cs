using UnityEngine;

namespace Imp
{
    public class SetTerrainZ : MonoBehaviour
    {
        [SerializeField] private float _additionalShift;
        
        private void Start()
        {
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform childTransform = transform.GetChild(i);
                Vector3 position = childTransform.position;
                position.z = position.y + _additionalShift;
                childTransform.position = position;
            }
        }
    }
}