using System;
using System.Collections.Generic;
using UnityEngine;

namespace jdmozo.Inventory
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory Instance;

        public List<InventoryItem> inventory = new List<InventoryItem>();
        private Dictionary<InventoryItemData, InventoryItem> itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();

        public static event Action<InventoryItemData> ItemAdded;
        public static event Action<InventoryItemData> ItemRemoved;


        private void Awake() => Instance = this;

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
                ItemAdded?.Invoke(itemData);
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
                    ItemRemoved?.Invoke(itemData);
                }
            }
        }
    }
}
