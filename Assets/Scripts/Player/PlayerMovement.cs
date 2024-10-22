using UnityEngine;

namespace Assets.Player
{
    public class PlayerMovement
    {
        private float _moveSpeed;
        private Camera _playerCamera;
        private Rigidbody _rigidBody;

        public PlayerMovement(Camera playerCamera, Rigidbody rigidBody, float moveSpeed)
        {
            _playerCamera = playerCamera;
            _rigidBody = rigidBody;
            _moveSpeed = moveSpeed;
        }

        public void Move(float moveHorizontal, float moveVertical)
        {
            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            movement = _playerCamera.transform.TransformDirection(movement);
            movement.y = 0;

            _rigidBody.MovePosition(_rigidBody.position + movement * _moveSpeed * Time.deltaTime);
        }
    }
}