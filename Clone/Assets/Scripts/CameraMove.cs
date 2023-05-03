using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Newtonsoft.Json.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
namespace Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class CameraMove : MonoBehaviour
    {
        public Quaternion TargetRotation { private set; get; }
        private new Rigidbody rigidbody;
        public float speed = 5f;
        public float jumpForce = 5f;
        public float cameraSpeed = 10.0f;
        private float raysize = 1.5f;
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            this.rigidbody = GetComponent<Rigidbody>();
            TargetRotation = transform.rotation;
        }

        private void Update()
        {
            AimCam();
            Move();
            Jump();
        }
        private void Jump()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, raysize))
            {
                //limitar o pulo para que uma vez execultado não seja possivel pular novamente até chegar no chão.
                if (Input.GetKeyDown(KeyCode.Space) && hit.collider.tag == "Ground" && rigidbody.velocity.y <= 0)
                {
                    rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                } 
            }
        }
        private void AimCam()
        {
            var rotation = new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
            var targetEuler = TargetRotation.eulerAngles + (Vector3)rotation * cameraSpeed;
            TargetRotation = transform.rotation;

            if (targetEuler.x > 180.0f)
            {
                targetEuler.x -= 360.0f;
            }
            targetEuler.x = Mathf.Clamp(targetEuler.x, -75.0f, 75.0f);
            TargetRotation = Quaternion.Euler(0, targetEuler.y, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation,
                Time.deltaTime * 15.0f);
        }
        private void Move()
        {

            float VAxes = Input.GetAxis("Vertical");
            float HAxes = Input.GetAxis("Horizontal");

            Vector3 dir = new Vector3(HAxes, 0, VAxes);
            this.transform.Translate(dir * speed * Time.deltaTime);

        }
        public void ResetTargetRotation()
        {
            TargetRotation = Quaternion.LookRotation(transform.forward, Vector3.up);
        }
    }
}