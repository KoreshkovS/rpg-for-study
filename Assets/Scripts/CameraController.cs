using UnityEngine;

namespace Game.Camera
{ 

    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _player = null;
        [SerializeField] private float _dumping = 0;


        private Vector3 target = Vector3.zero;
        private Vector2 _offset = new Vector2(2f, 1f);
        private int _lastX = 0;
        private int _currentX = 0;
        private bool _isLookingLeft = false;

        private void LateUpdate()
        {
            if (_player == null)
                return;

            _currentX = Mathf.RoundToInt(_player.position.x);
            if (_currentX > _lastX)
                _isLookingLeft = false;
            else if(_currentX < _lastX)
                _isLookingLeft = true;
            _lastX = Mathf.RoundToInt(_player.position.x);
            Move();
        }


        private void Move()
        {
            if(_isLookingLeft)
            {
                target = new Vector3(_player.position.x - _offset.x, _player.position.y + _offset.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, target, _dumping * Time.deltaTime);
            }
            else
            {
                target = new Vector3(_player.position.x + _offset.x, _player.position.y + _offset.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, target, _dumping * Time.deltaTime);

            }
        }
    }


}