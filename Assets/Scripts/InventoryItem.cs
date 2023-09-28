
using UnityEngine;

namespace Game.Items
{

    public enum PotionType { HpPotion, HpMaxPotion, MpPotion, MpMaxPotion, DamagePotion, SpeedPotion }
    [CreateAssetMenu(menuName = ("InventoryItem/Potion"))]

    public class InventoryItem : ScriptableObject
    {
        [SerializeField] private Sprite _itemImage = null;
        [SerializeField] private int _valueBaff = 0;
        [SerializeField] private PotionType _potionType = PotionType.HpMaxPotion;

        public PotionType PotionT => _potionType;
        public Sprite ItemImage => _itemImage;
        public int ValueBaff => _valueBaff;
    }
}