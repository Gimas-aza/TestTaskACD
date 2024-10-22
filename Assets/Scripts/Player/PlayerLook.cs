using UnityEngine;

namespace Assets.Player
{
    
    public class PlayerLook
    {
        private float _lookSpeed;
        private float _rotationX = 0f;
        private Camera _playerCamera;
        private Transform _transform;

        public PlayerLook(Camera camera, Transform transform, float lookSpeed)
        {
            _playerCamera = camera;
            _transform = transform;
            _lookSpeed = lookSpeed;
        }

        public void Look(float mouseX, float mouseY)
        {
            _rotationX -= mouseY * _lookSpeed;
            _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

            _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
            _transform.Rotate(Vector3.up * mouseX * _lookSpeed);
        }
    }
}