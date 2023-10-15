using System.Collections.Generic;
using UnityEngine;

namespace jdmozo.Inventory
{
    public class Inventory : MonoBehaviour
    {
        public List<InventoryItem> inventory = new List<InventoryItem>();
        private Dictionary<InventoryItemData, InventoryItem> itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();

        private void OnEnable()
        {
            CollectibleItem.OnItemCollected += Add;
        }

        private void OnDisable()
        {
            CollectibleItem.OnItemCollected -= Add;
        }

        public void Add(InventoryItemData itemData)
        {
            if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
            {
                item.AddToStack();
                Debug.Log($"{item._itemData.name} total stack is now {item.stackSize}");
            }
            else
            {
                InventoryItem newItem = new InventoryItem(itemData);
                inventory.Add(newItem);
                itemDictionary.Add(itemData, newItem);
                Debug.Log($"{itemData.name} total stack is now {newItem.stackSize}");
            }
        }

        public void Remove(InventoryItemData itemData)
        {
            if(itemDictionary.TryGetValue(itemData,out InventoryItem item))
            {
                item.RemoveFromStack();

                if (item.stackSize == 0)
                {
                    inventory.Remove(item);
                    itemDictionary.Remove(itemData);
                }
            }
        }
    }
}
