using UnityEngine;

namespace Controller
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed = 40f;
        [SerializeField] private float _moveSpeed = 40f;
        [SerializeField] private float _zoomSpeed = 10f;
        private int _directionRotation = 0;
        private float _acceleration;
        private float _verticalInput;
        private float _horizontalInput;

        private void Update()
        {
            RotateCamera();
            MoveCamera();
            ZoomCamera();
        }

        private void RotateCamera()
        {
            Acceleration(2f);

            if (Input.GetKey(KeyCode.Q))
            {
                _directionRotation = -1;
                transform.Rotate(Vector3.up * _rotateSpeed * _directionRotation * _acceleration * Time.deltaTime, Space.World);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                _directionRotation = 1;
                transform.Rotate(Vector3.up * _rotateSpeed * _directionRotation * _acceleration * Time.deltaTime, Space.World);
            }
        }

        private void MoveCamera()
        {
            Acceleration(2f);

            _verticalInput = Input.GetAxis("Vertical");
            _horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(new Vector3(_horizontalInput, 0f, _verticalInput) * _moveSpeed * Time.deltaTime * _acceleration, Space.Self);
        }

        private void Acceleration(float acceleration)
        {
            if (Input.GetKey(KeyCode.LeftShift)) { _acceleration = acceleration; }
            else { _acceleration = 1f; }
        }

        private void ZoomCamera()
        {
            transform.position += Input.GetAxis("Mouse ScrollWheel") * transform.up * _zoomSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -18f, 6f), transform.position.z);
        }
    }
}


