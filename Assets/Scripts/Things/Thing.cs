using UnityEngine;
using Assets.Player;

namespace Assets.Things
{
    [RequireComponent(typeof(Rigidbody))]
    public class Thing : MonoBehaviour, IInteractable
    {
        public Rigidbody Rigidbody { get; private set; }
        public Transform Transform { get; private set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Transform = GetComponent<Transform>();
        }
    }
}
