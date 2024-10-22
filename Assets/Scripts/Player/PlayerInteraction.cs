using UnityEngine;

namespace Assets.Player
{
    public class PlayerInteraction
    {
        private Camera _playerCamera;
        private float _interactionDistance;
        private Transform _holdPoint;
        private IInteractable _heldObject;

        public PlayerInteraction(Camera camera, Transform holdPoint, float interactionDistance)
        {
            _playerCamera = camera;
            _holdPoint = holdPoint;
            _interactionDistance = interactionDistance;
            _heldObject = null;
        }

        public void Interact(bool isInteracting)
        {
            if (_heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(
                    _playerCamera.transform.position,
                    _playerCamera.transform.forward,
                    out hit,
                    _interactionDistance
                ))
                {
                    if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
                    {
                        _heldObject = interactable;
                        _heldObject.Rigidbody.isKinematic = true;
                        _heldObject.Transform.position = _holdPoint.position;
                        _heldObject.Transform.SetParent(_holdPoint);
                    }
                }
            }
            else
            {
                _heldObject.Rigidbody.isKinematic = false;
                _heldObject.Transform.SetParent(null);
                _heldObject = null;
            }
        }
    }
}