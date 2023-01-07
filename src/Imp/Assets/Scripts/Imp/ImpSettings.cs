using UnityEngine;

namespace Imp
{
    [CreateAssetMenu(fileName = "ImpSettings", menuName = "Static Data/Create Imp Settings", order = 0)]
    public class ImpSettings : ScriptableObject
    {
        public float WalkSpeed = 2.5f;
        public float InteractSquareDistance = 0.2f;
        public int InventorySize = 3;
    }
}