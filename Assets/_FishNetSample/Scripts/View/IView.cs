using Cysharp.Threading.Tasks;

namespace _FishNetSample.Scripts.View
{
    public interface IView
    {
        UniTask Initialize();
        void Show();
        void Hide();
    }
}