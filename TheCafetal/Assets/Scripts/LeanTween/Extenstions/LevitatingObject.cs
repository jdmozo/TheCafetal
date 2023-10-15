using UnityEngine;

namespace jdmozo
{ 
    public class LevitatingObject : MonoBehaviour
    {
        public float levitateDistance = 1.0f;
        public float levitateDuration = 1.0f;

        private Vector3 originalPosition;

        private void Start()
        {
            originalPosition = transform.position;
            StartLevitate();
        }

        private void StartLevitate()
        {
            LeanTween.moveLocalY(gameObject, originalPosition.y + levitateDistance, levitateDuration)
                .setEase(LeanTweenType.easeInOutQuad)
                .setOnComplete(() => { // When the object reaches the top
                    LeanTween.moveLocalY(gameObject, originalPosition.y - levitateDistance, levitateDuration)
                        .setEase(LeanTweenType.easeInOutQuad)
                        .setOnComplete(StartLevitate); // Start the levitation again
                });
        }
    }

}
