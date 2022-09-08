using UniRx;
using UnityEngine;

public class SampleModel : MonoBehaviour
{
    public ReactiveProperty<int> score = new ReactiveProperty<int>();
}
