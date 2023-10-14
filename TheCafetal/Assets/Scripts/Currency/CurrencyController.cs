using System;
using TMPro;
using UnityEngine;

namespace jdmozo.Inventory
{
    public class CurrencyController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _actualCurrency;

        private void OnEnable() => CurrencyItem.OnCurrencyCollected += ChangeCurrencyValue;

        private void OnDisable() => CurrencyItem.OnCurrencyCollected -= ChangeCurrencyValue;

        public void ChangeCurrencyValue(int value)
        {
            Currency.Instance.currency += value ;
            _actualCurrency.text = Currency.Instance.currency.ToString();
        }
    }
}
