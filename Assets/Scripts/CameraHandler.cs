using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class CameraHandler : MonoBehaviour
    {
        public float minX = -60f;
        public float maxX = 60f;

        public float sensitivity = 5f;

        private float _rotY = 0f;
        private float _rotX = 0f;

        private bool _lockedCamera = false;

        private Vector3 _startAngle;

        void Start()
        {
            _startAngle = transform.eulerAngles;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }

        void Update()
        {
            if (!_lockedCamera)
            {
                _rotY += Input.GetAxis("Mouse X") * sensitivity;
                _rotX += Input.GetAxis("Mouse Y") * sensitivity;

                _rotX = Mathf.Clamp(_rotX, minX, maxX);

                transform.localEulerAngles = new Vector3(-_rotX, _rotY, 0);

            }
        }

        public void LookAtThis(Vector3 target)
        {
            Cursor.lockState = CursorLockMode.None;
            transform.LookAt(target);
            _lockedCamera = true;
        }

        public void UnlockCamera()
        {
            transform.eulerAngles = _startAngle;
            _lockedCamera = false;
        }
    }
}