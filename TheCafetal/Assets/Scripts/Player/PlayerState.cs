using UnityEngine;

namespace jdmozo
{
    public class PlayerState : MonoBehaviour
    {
        public static PlayerState Instance;

        public bool canOpenStore;

        private void Awake() => Instance = this;

        private void Update()
        {
            if (canOpenStore &&
                PlayerMenus.Instance.openMenus <= 1 &&
                Input.GetKeyDown(KeyCode.Space))
            {
                PlayerMenus.Instance.SetShop(!PlayerMenus.Instance.menuIsOpen);
                PlayerMenus.Instance.menuIsOpen = !PlayerMenus.Instance.menuIsOpen;
            }

            if (PlayerMenus.Instance.openMenus <= 1 &&
                Input.GetKeyDown(KeyCode.I))
            {
                PlayerMenus.Instance.SetInventory(!PlayerMenus.Instance.menuIsOpen);
                PlayerMenus.Instance.menuIsOpen = !PlayerMenus.Instance.menuIsOpen;
            }
        }

        public void CanOpenStore(bool value) => canOpenStore = value;


    }
}
