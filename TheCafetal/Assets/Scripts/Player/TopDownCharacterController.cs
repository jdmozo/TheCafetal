using UnityEngine;

namespace jdmozo.Player
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float _speed;

        private Animator _animator;
        private SpriteRenderer _playerSprite;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _playerSprite = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!PlayerMenus.Instance.menuIsOpen)
            {
                Movement();
                _rigidbody2D.WakeUp();
            }
            else
            {
                _rigidbody2D.Sleep();
            }
        }

        private void Movement()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                dir.x = -1;
                _playerSprite.flipX = true;
                _animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                dir.x = 1;
                _playerSprite.flipX = false;
                _animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                dir.y = 1;
                _animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                dir.y = -1;
                _animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            _animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = _speed * dir;
        }
    }
}
