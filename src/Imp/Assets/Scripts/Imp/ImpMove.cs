using UnityEngine;

namespace Imp
{
    public class ImpMove : MonoBehaviour
    {
        [SerializeField] private float _walkSpeed = 10f;

        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 position = transform.position;
            float deltaTime = Time.deltaTime;
            position.x += horizontal * _walkSpeed * deltaTime;
            position.y += vertical * _walkSpeed * deltaTime;
            position.z = position.y;
            transform.position = position;
        }
    }
}