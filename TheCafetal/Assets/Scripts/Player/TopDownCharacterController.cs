using UnityEngine;

namespace jdmozo.Player
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (dir.x < 0)
            {
                animator.SetInteger("Direction", 3); // Left
            }
            else if (dir.x > 0)
            {
                animator.SetInteger("Direction", 2); // Right
            }

            if (dir.y > 0)
            {
                animator.SetInteger("Direction", 1); // Up
            }
            else if (dir.y < 0)
            {
                animator.SetInteger("Direction", 0); // Down
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
