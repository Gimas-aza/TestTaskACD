using System;

namespace Assets.Player
{
    public interface IInput
    {
        event Action<float, float> OnMove;   
        event Action<float, float> OnLook;
        event Action<bool> OnInteract;
    }
}