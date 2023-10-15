using UnityEngine;

namespace jdmozo
{
    public class PlayerMenus : MonoBehaviour
    {
        public static PlayerMenus Instance;

        [SerializeField] private GameObject _inventoryMenu;
        [SerializeField] private GameObject _shopMenu;
        public bool menuIsOpen = false;
        public int openMenus = 0;

        private void Awake() => Instance = this;

        public void SetShop(bool value)
        {
            _shopMenu.SetActive(value);
            openMenus = value ? openMenus + 1 : openMenus - 1;
        }

        public void SetInventory(bool value)
        {
            _inventoryMenu.SetActive(value);
            openMenus = value ? openMenus + 1 : openMenus - 1;
        }
    }
}
