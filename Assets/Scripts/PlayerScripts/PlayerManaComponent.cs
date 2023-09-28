using System;
using Game.Items;
using UnityEngine;

public class PlayerManaComponent : MonoBehaviour
{
    [SerializeField] private int _maxMana = 0;

    private int _currentMana = 0;

    public event Action<int, int> OnChangeMana;


    public int CurrentMana => _currentMana;

    private void Awake()
    {
        _currentMana = _maxMana;
    }

    public void ChangeCurrentMana(int value)
    {
        _currentMana -= value;
        OnChangeMana?.Invoke(_currentMana, _maxMana);
    }

    public void DrinkMpPotion(object[] arg2)
    {
        _currentMana += (int)arg2[0];

    }

    public void DrinkMaxMpPotion(object[] arg2)
    {
        _currentMana += (int)arg2[0];
        PlayerDataStore.SaveMaxMana((int)_maxMana);
    }

    private void OnEnable()
    {
        EventBus.SubScribe(PotionType.MpPotion, DrinkMpPotion);
        EventBus.SubScribe(PotionType.MpMaxPotion, DrinkMaxMpPotion);
    }

    private void OnDisable()
    {
        EventBus.UnSubscribe(PotionType.MpPotion, DrinkMpPotion);
        EventBus.UnSubscribe(PotionType.MpMaxPotion, DrinkMaxMpPotion);
    }
}
