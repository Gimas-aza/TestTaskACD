using Assets.DI;
using Assets.InputController;
using Assets.Player;
using UnityEngine;

namespace Assets.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;

        private IDIContainer _container;
        private IInitializer _player;

        private void Awake()
        {
            _container = new DIContainer();
            _player = CreateObject(_playerController);

            Register();

            _player.Init(_container);
        }

        private T CreateObject<T>(T obj) where T : Object
        {
            return GameObject.Instantiate<T>(obj);
        }

        private void Register()
        {
            _container.RegisterSingleton((c) => 
            {
                IInitializer input = new InputController.Input();
                input.Init(c);
                return input as IInput;
            });
        }
    }
}
