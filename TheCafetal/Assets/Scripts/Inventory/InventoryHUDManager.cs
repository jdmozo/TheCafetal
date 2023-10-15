using System.Collections.Generic;
using UnityEngine;

namespace jdmozo.Inventory
{
    public class InventoryHUDManager : MonoBehaviour
    {
        [SerializeField] private Transform _inventorySlotParent;
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private List<GameObject> _inventorySlots;

        private void Start() => GetInvenotyHUDSlots();

        private void GetInvenotyHUDSlots()
        {
            for (int i = 0; i < _inventorySlotParent.childCount; i++)
                _inventorySlots.Add(_inventorySlotParent.GetChild(i).gameObject);
        }
    }
}
