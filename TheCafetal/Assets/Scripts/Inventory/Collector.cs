using UnityEngine;

namespace jdmozo.Inventory
{
    public class Collector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            ICollectible collectible = collision.GetComponent<ICollectible>();
            if (collectible != null)
            {
                collectible.Collect();
                collision.gameObject.SetActive(false);

            }
        }
    }
}
