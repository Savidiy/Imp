using UnityEngine;

namespace Imp
{
    public class Interactable : MonoBehaviour
    {
        public Transform BubblePosition;

        public void Interact()
        {
            IInteractLogic[] interactLogics = GetComponents<IInteractLogic>();
            foreach (IInteractLogic interactLogic in interactLogics)
            {
                interactLogic.Interact(this);
            }
        }
    }
}