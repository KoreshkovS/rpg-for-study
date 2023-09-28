using Game.Items;
using UnityEngine;

namespace Game.Player
{ 

public class PlayerMove : MonoBehaviour
{
        [SerializeField] private float _jumpForce = 0;
        [SerializeField] private Transform _groundChacker = null;
        [SerializeField] private float _groundRadius = 0;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _stairSpeed = 0;
        [SerializeField] private int _myLayer = 0;
        [SerializeField] private int _ignoreLayer = 0;
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _speed = 0;



        [SerializeField] private bool _isStair = false;
        private bool _facingRight = true;
        private bool _isGround = false;  

        public bool IsGround { get => _isGround;}

        public void Move()
        {
            

            Vector2 velocity = _rigidBody.velocity;
            velocity.x = Input.GetAxis("Horizontal") * _speed;
            _rigidBody.velocity = velocity;

            if (Input.GetAxis("Horizontal") > 0 && !_facingRight)
            {
                Flip();
            } else if(Input.GetAxis("Horizontal") < 0 && _facingRight)
            {
                Flip();
            }
        }

        public void MoveInStair()
        {
            if (_isStair)
            {
                Vector2 velocity = _rigidBody.velocity;
                velocity.y = Input.GetAxis("Vertical") * _stairSpeed;
                _rigidBody.velocity = velocity;
            }
        }

        

        public void Jump()
        {
            CheckingGround();
            if (_isGround)
            {
                _rigidBody.AddForce(Vector2.up * _jumpForce);
            }
            else
                _rigidBody.gravityScale = 1;
        }

        public void CheckingGround()
        {
            _isGround = Physics2D.OverlapCircle(_groundChacker.position, _groundRadius,_groundLayer);
        }

        private void Flip()
        {
            _facingRight = !_facingRight;
            transform.Rotate(0f, 180f, 0f);
        }

        public void IsStair(bool isStair)
        {
            Physics2D.IgnoreLayerCollision(_myLayer, _ignoreLayer, isStair);
            _isStair = isStair;
            if (isStair)
            {
                _rigidBody.gravityScale = 0;
            } else
            {
                _rigidBody.gravityScale = 1;
            }
        }

        private void AddSpeed(object[] arg)
        {
            _speed += (int)arg[0]; //чому арг 0?
            PlayerDataStore.SaveSpeed((int)_speed);
        }


        private void OnEnable()
        {
            EventBus.SubScribe(PotionType.SpeedPotion, AddSpeed);
        }
        private void OnDisable()
        {
            EventBus.UnSubscribe(PotionType.SpeedPotion, AddSpeed);
        }

    }

}