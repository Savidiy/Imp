using UnityEngine;

namespace Imp
{
    public class SetTerrainY : MonoBehaviour
    {
        void Start()
        {
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform childTransform = transform.GetChild(i);
                Vector3 position = childTransform.position;
                position.z = position.y;
                childTransform.position = position;
            }
        }
    }
}