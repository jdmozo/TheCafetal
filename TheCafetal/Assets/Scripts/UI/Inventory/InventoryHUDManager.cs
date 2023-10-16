using System.Collections.Generic;
using UnityEngine;
using jdmozo.Inventory;
using System.Collections;

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

        private void OnDisable()
        {
            InventoryManager.ItemAdded -= AddItemHUD;
        }

        private void Start()
        {
            GetInvenotyHUDSlots();
        }

        private void GetInvenotyHUDSlots()
        {
            for (int i = 0; i < _inventorySlotParent.childCount; i++)
            {
                _inventorySlots.Add(_inventorySlotParent.GetChild(i).gameObject);
                _inventorySlots[i].GetComponent<SlotController>().slotID = i;
            }
        }

        public void AddItemHUD(InventoryItemData data)
        {
            StartCoroutine(AddItemHUDPCoroutine(data));
        }

        private IEnumerator AddItemHUDPCoroutine(InventoryItemData data)
        {
            for (int i = 0; i < _inventorySlots.Count; i++)
            {
                int temp = i;
                if (_inventorySlots[temp].GetComponent<SlotController>()._ocupied &&
                    _inventorySlots[temp].GetComponent<SlotController>().inventoryItem._itemData.itemID == data.itemID)
                {
                    _inventorySlots[temp].GetComponent<SlotController>().inventoryItem.UpdateInfo();
                    break;
                }
                else if (!_inventorySlots[temp].GetComponent<SlotController>()._ocupied)
                {
                    GameObject prefab = Instantiate(_itemPrefab, _inventorySlotParent.GetChild(temp).transform);
                    prefab.GetComponent<InventoryItem>()._itemData = data;

                    _inventorySlots[temp].GetComponent<SlotController>().inventoryItem = prefab.GetComponent<InventoryItem>();
                    _inventorySlots[temp].GetComponent<SlotController>().itemData = data;
                    _inventorySlots[temp].GetComponent<SlotController>()._ocupied = true;

                    yield return new WaitUntil(() =>  _inventorySlots[temp].GetComponent<SlotController>().itemData);
                    _inventorySlots[temp].GetComponent<SlotController>().SelectItem();
                    prefab.GetComponent<InventoryItem>().UpdateInfo();
                    break;
                }

            }
        }
    }
}
