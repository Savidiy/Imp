using UnityEngine;

namespace Imp
{
    public class ActiveSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject _observableGameObject;

        private void Update()
        {
            gameObject.SetActive(!_observableGameObject.activeInHierarchy);
        }
    }
}