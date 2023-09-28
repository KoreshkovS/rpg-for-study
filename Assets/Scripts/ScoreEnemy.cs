using System;
using Game.BaseEntity;
using UnityEngine;
using UnityEngine.Networking.Types;

public class ScoreEnemy : MonoBehaviour
{
    public static event Action<int> OnNeedChangeScore;

    [SerializeField] private BaseHealthComponent _healthComponent;
    [SerializeField] private int _dieScore = 0;
 

   

    private void OnEnable()
    {
        _healthComponent.OnHealthNull += NeedChangeScore;
    }
    private void OnDisable()
    {
        _healthComponent.OnHealthNull -= NeedChangeScore;
    }
    private void NeedChangeScore()
    {
        OnNeedChangeScore?.Invoke(_dieScore);
    }


}
