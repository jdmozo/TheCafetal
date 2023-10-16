using jdmozo.Player;
using UnityEngine;

public class ShopInteraction : MonoBehaviour
{
    [SerializeField] private GameObject _popUpInteract;
    private bool isPopupShowing = false;
    Vector3 _popUpScale;

    private void Start()
    {
        _popUpInteract.SetActive(false);
        _popUpScale = _popUpInteract.transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isPopupShowing)
            {
                isPopupShowing = true;

                // Scale up animation
                LeanTween.scale(_popUpInteract, _popUpScale, 0.3f)
                    .setEase(LeanTweenType.easeOutBack)
                    .setOnStart(() => _popUpInteract.SetActive(true));
            
                collision.GetComponent<PlayerState>().CanOpenStore(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isPopupShowing)
            {
                // Scale down animation
                LeanTween.scale(_popUpInteract, Vector3.zero, 0.3f)
                    .setEase(LeanTweenType.easeInBack)
                    .setOnComplete(() =>
                    {
                        // Reset the flag and deactivate the pop-up after the animation
                        isPopupShowing = false;
                        _popUpInteract.SetActive(false);
                    });

                collision.GetComponent<PlayerState>().CanOpenStore(false);
            }
        }
    }
}
