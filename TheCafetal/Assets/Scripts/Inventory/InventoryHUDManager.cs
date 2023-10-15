using System.Collections.Generic;
using UnityEngine;
using jdmozo.Inventory;

namespace jdmozo.UI
{
    public class InventoryHUDManager : MonoBehaviour
    {
        [SerializeField] private Transform _inventorySlotParent;
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private List<GameObject> _inventorySlots;

        private void OnEnable()
        {
            InventoryManager.ItemAdded += AddItemHUD;
        }

        private void Start() => GetInvenotyHUDSlots();

        private void GetInvenotyHUDSlots()
        {
            for (int i = 0; i < _inventorySlotParent.childCount; i++)
                _inventorySlots.Add(_inventorySlotParent.GetChild(i).gameObject);
        }

        public void AddItemHUD(InventoryItemData data)
        {

        }
    }
}
