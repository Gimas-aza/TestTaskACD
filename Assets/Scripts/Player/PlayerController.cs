using Assets.EntryPoint;
using UnityEngine;

namespace Assets.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour, IInitializer
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _lookSpeed = 2f;
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private float _interactionDistance = 3f;
        [SerializeField] private Transform _holdPoint;

        private Rigidbody _rigidBody;

        public void Init(IResolver container)
        {
            _rigidBody = GetComponent<Rigidbody>();

            var input = container.Resolve<IInput>();
            var playerMovement = new PlayerMovement(_playerCamera, _rigidBody, _moveSpeed);
            var playerLook = new PlayerLook(_playerCamera, transform, _lookSpeed);
            var playerInteraction = new PlayerInteraction(_playerCamera, _holdPoint, _interactionDistance);

            input.OnMove += playerMovement.Move;
            input.OnLook += playerLook.Look;
            input.OnInteract += playerInteraction.Interact;
        }
    }
}
