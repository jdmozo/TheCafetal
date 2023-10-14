using UnityEngine;

namespace jdmozo.Inventory
{
    public class Currency : MonoBehaviour
    {
        public static Currency Instance;
        public int currency;

        private void Awake()
        {
            Instance = this;
        }
    }
}
