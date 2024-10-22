using UnityEngine;

namespace Assets.Player
{
    public interface IInteractable
    {
        Rigidbody Rigidbody { get; }
        Transform Transform { get; }
    }
}