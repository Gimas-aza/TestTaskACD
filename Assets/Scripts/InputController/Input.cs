using System;
using Assets.EntryPoint;
using Assets.Player;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.InputController
{
    public class Input : IInput, IInitializer
    {
        public event Action<float, float> OnMove;
        public event Action<float, float> OnLook;
        public event Action<bool> OnInteract;

        public void Init(IResolver container)
        {
            Cursor.lockState = CursorLockMode.Locked;
            FixedUpdate();
            Update();
        }

        private async void FixedUpdate()
        {
            while (true)
            {
                float moveHorizontal = UnityEngine.Input.GetAxis("Horizontal");
                float moveVertical = UnityEngine.Input.GetAxis("Vertical");

                if (moveHorizontal != 0 || moveVertical != 0)
                    OnMove?.Invoke(moveHorizontal, moveVertical);

                await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
            }
        }

        private async void Update()
        {
            while (true)
            {
                float mouseX = UnityEngine.Input.GetAxis("Mouse X");
                float mouseY = UnityEngine.Input.GetAxis("Mouse Y");

                if (mouseX != 0 || mouseY != 0)
                    OnLook?.Invoke(mouseX, mouseY);

                if (UnityEngine.Input.GetKeyDown(KeyCode.E))
                {
                    OnInteract?.Invoke(true);
                } 

                await UniTask.Yield(PlayerLoopTiming.Update);
            }
        }
    }
}