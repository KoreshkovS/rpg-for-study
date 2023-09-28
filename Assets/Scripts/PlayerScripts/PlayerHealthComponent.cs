using System.Collections;
using System.Collections.Generic;
using Game.Items;
using UnityEngine;

public class PlayerHealthComponent : BaseHealthComponent
{
    public void DrinkHPPotion(object[] arg2)
    {
        _health += (int)arg2[0];
       
    }

    public void DrinkMaxHPPotion(object[] arg2)
    {
        _health += (int)arg2[0];
        PlayerDataStore.SaveMaxHealth((int)maxHealth);
    }

    private void OnEnable()
    {
        EventBus.SubScribe(PotionType.HpPotion, DrinkHPPotion);
        EventBus.SubScribe(PotionType.HpMaxPotion, DrinkMaxHPPotion);
    }

    private void OnDisable()
    {
        EventBus.UnSubscribe(PotionType.HpPotion, DrinkHPPotion);
        EventBus.UnSubscribe(PotionType.HpMaxPotion, DrinkMaxHPPotion);
    }
}
