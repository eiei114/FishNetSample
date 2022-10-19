using System.Threading;
using Cysharp.Threading.Tasks;

namespace _FishNetSample.Scripts.View
{
    public interface IView
    {
        UniTask Initialize(CancellationToken token);
        void Show();
        void Hide();
    }
}