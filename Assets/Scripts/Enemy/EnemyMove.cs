using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints = null;
    [SerializeField] private float _speed = 0;

    public float Speed => _speed;

    private int _index = 0;
    private bool _isMove = false;

    public void Move()
    {
        if (_isMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_index].transform.position, _speed *Time.deltaTime);
            if (transform.position == _wayPoints[_index].transform.position)
            {
                _index++;
                transform.Rotate(0f, 180f, 0f);
            }

            if (_index == _wayPoints.Length)
            {
                _index = 0;
            }
        }
    }

    public void StartMove()
    {
        _isMove = true;
    }

    public void StopMove()
    {
        _isMove = false;
    }
}
