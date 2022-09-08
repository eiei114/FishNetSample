
using UniRx;
using UnityEngine;

public class SamplePresenter : MonoBehaviour
{
    [SerializeField]
    private SampleView sampleView;

    [SerializeField]
    private SampleModel sampleModel;

    private void Start()
    {
        sampleView.OnButtonClicked.Subscribe(_ =>
        {
            Debug.Log("Button Clicked");
            AddScore();
        }).AddTo(this);

        sampleModel.score.Subscribe(value =>
        {
            Debug.Log("scored");
            sampleView.ScoreText = value.ToString();
        }).AddTo(this);
    }
    
    private void AddScore()
    {
        sampleModel.score.Value++;
    }
}
