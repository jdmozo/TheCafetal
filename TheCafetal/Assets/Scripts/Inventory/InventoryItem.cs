using System;
using UnityEngine;

namespace jdmozo.Inventory
{
    [Serializable]
    public class InventoryItem : MonoBehaviour
    {
        public InventoryItemData _itemData;
        public int stackSize;

        public InventoryItem(InventoryItemData itemData)
        {
            _itemData = itemData;
            AddToStack();
        }

        public void AddToStack() => stackSize++;

        public void RemoveFromStack() => stackSize--;
    }
}
