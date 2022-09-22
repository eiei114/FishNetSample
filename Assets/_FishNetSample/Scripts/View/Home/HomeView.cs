using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _FishNetSample.Scripts.View.Home
{
    public class HomeView : MonoBehaviour, IView
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private InputField _nameInputField;

        private readonly Subject<string> _nameInputSubject = new Subject<string>();
        private readonly Subject<Unit> _startButtonSubject = new Subject<Unit>();

        public IObservable<string> NameInputObservable => _nameInputSubject;
        public IObservable<Unit> StartButtonObservable => _startButtonSubject;

        

        public async UniTask Initialize()
        {

            // ボタンのクリックイベントを購読
            _startButton.OnClickAsObservable().Subscribe(_ => _startButtonSubject.OnNext(Unit.Default)).AddTo(this);

            // 入力フィールドの入力イベントを購読
            _nameInputField.OnValueChangedAsObservable().Subscribe(value => _nameInputSubject.OnNext(value)).
                AddTo(this);
        }

        public void Show() { gameObject.SetActive(true); }

        public void Hide() { gameObject.SetActive(false); }
    }
}