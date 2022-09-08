using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SampleView : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private Text text;
    
    Subject<Unit> onButtonClicked = new Subject<Unit>();

    public IObservable<Unit> OnButtonClicked
    {
      get { return onButtonClicked; }  
    } 

    public string ScoreText
    {
        get => text.text;
        set => text.text = value;
    }
    private void Awake() { button.OnClickAsObservable().Subscribe(_ => onButtonClicked.OnNext(Unit.Default)).AddTo(this); }
}
