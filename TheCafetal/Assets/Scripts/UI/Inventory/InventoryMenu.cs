using jdmozo.Inventory;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace jdmozo.UI
{
    public class InventoryMenu : MonoBehaviour
    {
        [SerializeField] private Image _playerPreview;

        [SerializeField] private Transform _inventorySlotParent;
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private List<GameObject> _inventorySlots;

        private void Awake()
        {
            GetInventorySlots();
        }

        private void OnEnable()
        {
            _inventorySlots[InventoryManager.Instance.CurrentHUDSelected].GetComponent<Toggle>().isOn = true;

            foreach (var item in InventoryManager.Instance.itemDictionary) 
            {
                ShowPreview(item.Key);
            }
        }

        private void GetInventorySlots()
        {
            for (int i = 0; i < _inventorySlotParent.childCount; i++)
            {
                _inventorySlots.Add(_inventorySlotParent.GetChild(i).gameObject);
                _inventorySlots[i].GetComponent<SlotController>().slotID = i;
            }
        }

        public void ShowPreview(InventoryItemData data)
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

                    _inventorySlots[temp].GetComponent<SlotController>().SelectItem();
                    prefab.GetComponent<InventoryItem>().UpdateInfo();
                    break;
                }
            }
        }

        public void CleanPreview()
        {
            for (int i = 0; i < _inventorySlots.Count; i++)
            {
                int temp = i;
                Destroy(_inventorySlots[temp].transform.GetChild(1));
            }
        }

        public void Equip(InventoryItemData itemData) => _playerPreview.color = itemData.clothesColor;

        public void Equip() => _playerPreview.color = Color.white;
    }
}
