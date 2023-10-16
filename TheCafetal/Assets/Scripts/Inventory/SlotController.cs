using jdmozo.Inventory;
using jdmozo.Player;
using UnityEngine;
using UnityEngine.UI;

namespace jdmozo.UI
{
    public class SlotController : MonoBehaviour
    {
        public int slotID;
        public bool _ocupied;
        public InventoryItemData itemData;
        public InventoryItem inventoryItem;
        [SerializeField] private Toggle _toggle;

        private void Start()
        {
            if (!_toggle.isOn)
                SetGraphicTarget(false);

            _toggle.onValueChanged.AddListener(delegate { SelectItem(); });
        }

        public void SetGraphicTarget(bool value)
        {
            if (!_toggle.isOn)
                _toggle.targetGraphic.enabled = value;
        }

        public void SelectItem()
        {
            InventoryManager.Instance.CurrentHUDSelected = slotID;

            if (_toggle.isOn && itemData)
            {
                PlayerState.Instance.ChangeClothesColor(itemData.clothesColor);
                InventoryManager.Instance.inventoryMenu.Equip(itemData);
            }
            else if (itemData)
            {
                PlayerState.Instance.ChangeClothesColor();
                InventoryManager.Instance.inventoryMenu.Equip();
            }

        }

    }
}
