using Assets.InputController;

namespace Assets.EntryPoint
{
    public interface IInitializer
    {
        void Init(IResolver container);
    }
}