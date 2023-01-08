using System.Collections.Generic;
using UnityEngine;

namespace Imp
{
    [RequireComponent(typeof(Interactable))]
    internal sealed class ActivateInteractLogic : MonoBehaviour, IInteractLogic
    {
        [SerializeField] private List<GameObject> _parentsOfActivatedObjects;
        [SerializeField] private List<GameObject> _activatedObjects;

        public void Interact(Interactable interactable)
        {
            foreach (GameObject parentOfActivatedObject in _parentsOfActivatedObjects)
            {
                Transform parentTransform = parentOfActivatedObject.transform;
                int childCount = parentTransform.childCount;
                for (int i = 0; i < childCount; i++)
                {
                    Transform child = parentTransform.GetChild(i);
                    child.gameObject.SetActive(true);
                }
            }

            foreach (GameObject activatedObject in _activatedObjects)
            {
                activatedObject.SetActive(true);
            }
        }
    }
}