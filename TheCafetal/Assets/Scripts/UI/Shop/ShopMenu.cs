using jdmozo.Inventory;
using jdmozo.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace jdmozo
{
    public class ShopMenu : MonoBehaviour
    {
        [SerializeField] private List<StoreStock> _shopList = new List<StoreStock>();

        [SerializeField] private Transform _inventorySlotParent;
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private List<GameObject> _inventorySlots;

        [SerializeField] private TMP_Text _itemNameText;
        [SerializeField] private TMP_Text _itemDescriptionText;
        [SerializeField] private TMP_Text _itemPriceText;

        private void Awake()
        {
            GetInventorySlots();
        }

        private void Start()
        {
            for (int i = 0; i < _shopList.Count; i++)
                ShowPreview(_shopList[i].itemData);

            for (int i = 0; i < _inventorySlots.Count; i++)
            {
                int temp = i;
                _inventorySlots[i].GetComponent<Toggle>().onValueChanged.AddListener(delegate { SelectAnItem(_inventorySlots[temp].GetComponent<SlotController>().itemData); });
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
                    _inventorySlots[temp].GetComponent<SlotController>().inventoryItem.UpdateInfoStore(_shopList[temp].itemStock);
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
                    prefab.GetComponent<InventoryItem>().UpdateInfoStore(_shopList[temp].itemStock);
                    break;
                }
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
    
        private void SelectAnItem(InventoryItemData data)
        {
            _itemNameText.text = data.itemName;
            _itemDescriptionText.text = data.itemDescription;
            _itemPriceText.text = data.itemSellPrice.ToString();
        }
    }

    [System.Serializable]
    public struct StoreStock
    {
        public InventoryItemData itemData;
        public int itemStock;
    }
}
