using jdmozo.Inventory;
using UnityEngine;

namespace jdmozo.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        [SerializeField] private AudioSource audioSource;

        [SerializeField] private AudioClip coinSound,pickupSound, ChestSound;

        private void Awake() => Instance = this;

        private void OnEnable()
        {
            CurrencyItem.OnItemCollected += PlayCurrencySFX;
        }

        private void OnDisable()
        {
            CurrencyItem.OnItemCollected -= PlayCurrencySFX;
        }

        public void PlayCurrencySFX()
        {
            audioSource.clip = coinSound;
            audioSource.Play();
        }


    }
}
