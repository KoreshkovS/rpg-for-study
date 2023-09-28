using System.Collections;
using System.Collections.Generic;
using Game.Items;
using Game.Player;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private InventoryItem[] _inventoryItems;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            int randomItem = Random.Range(0, _inventoryItems.Length);

            HUD.Instance.CreateIvnerotryItem(_inventoryItems[randomItem]);
            Destroy(gameObject);
        }

    }
}

