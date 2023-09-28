using Game.Items;
using UnityEngine;

    public class Inventory : MovePanel
    {

        [SerializeField] private Transform _parentInventoryItem = null;
        [SerializeField] private InventoryUIButton _buttonPrefab = null;


        public void CreateIvnerotryItem(InventoryItem item)
        {
            InventoryUIButton inventoryUIButton = Instantiate(_buttonPrefab, _parentInventoryItem);
            inventoryUIButton.InitItem(item);



        }

    }
