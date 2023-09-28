using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Items { 

public class InventoryUIButton : MonoBehaviour
{
    [SerializeField] private Image _itemImage = null;
    [SerializeField] private Button _myButton = null;

    public void InitItem(InventoryItem inventoryItem)
    {
        _itemImage.sprite = inventoryItem.ItemImage;
        _myButton.onClick.AddListener(() => Click(inventoryItem.PotionT, inventoryItem.ValueBaff));

    }

    public void Click(PotionType potionType, int value)
    {
        EventBus.BroadCast(potionType, value);
    }
}
}