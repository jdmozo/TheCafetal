using UnityEngine;

namespace jdmozo.Inventory
{
    [CreateAssetMenu(menuName = "Inventory Item")]
    public class InventoryItemData : ScriptableObject
    {
        public string itemID;
        public string itemName;
        [TextArea] public string itemDescription;
        public int itemSellPrice;
        public int itemBuyPrice;
        public Sprite itemIcon;
        public GameObject itemPrefab;
        public Color clothesColor;
    }
}
