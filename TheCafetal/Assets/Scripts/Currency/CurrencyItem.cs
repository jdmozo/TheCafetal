using System;
using UnityEngine;

namespace jdmozo.Inventory
{
    public class CurrencyItem : Collectible
    {
        public static event Action OnItemCollected;
        public static event Action<int> OnCurrencyCollected;

        [SerializeField] private int value;

        public override void Collect()
        {
            OnItemCollected?.Invoke();
            OnCurrencyCollected?.Invoke(value);
        }
    }
}
