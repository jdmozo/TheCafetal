using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace jdmozo.Inventory
{
    [Serializable]
    public class InventoryItem : MonoBehaviour
    {
        public InventoryItemData _itemData;
        public Image _itemImage;
        public TMP_Text _itemStackText;
        public int stackSize;

        public InventoryItem(InventoryItemData itemData)
        {
            _itemData = itemData;
            AddToStack();
        }

        public void UpdateInfo()
        {
            _itemImage.sprite = _itemData.itemIcon;
            int _currentStack = 0;

            if (InventoryManager.Instance.itemDictionary.TryGetValue(_itemData, out InventoryItem item))
                _currentStack = item.stackSize;

            _itemStackText.text = _currentStack.ToString();
        }

        public void UpdateInfoStore(int storeStack)
        {
            _itemImage.sprite = _itemData.itemIcon;
            _itemStackText.text = storeStack.ToString();
        }

        public void AddToStack() => stackSize++;

        public void RemoveFromStack() => stackSize--;
    }
}
