using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Imp
{
    [RequireComponent(typeof(Interactable))]
    internal sealed class ActivateInteractLogic : MonoBehaviour, IInteractLogic
    {
        [SerializeField] private List<GameObject> _parentsOfActivatedObjects;

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
        }
    }
}