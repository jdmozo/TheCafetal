using System;
using UnityEngine;

namespace jdmozo.Inventory
{
    public class CollectibleItem : Collectible
    {
        public static event Action<InventoryItemData> OnItemCollected;

        [SerializeField] private InventoryItemData itemData;

        public override void Collect()
        {
            OnItemCollected?.Invoke(itemData);
        }
    }
}
