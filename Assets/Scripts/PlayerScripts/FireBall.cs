using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private int _damage = 0;
    [SerializeField] private Rigidbody2D _rigidBody = null;
    [SerializeField] private float _shotPower = 0;

    public void Throw(Transform direction)
    {
        _rigidBody.AddForce(direction.right * _shotPower);
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDestructible destructible = collision.GetComponent<IDestructible>();
        if (destructible != null && collision.tag != "Player")
        {
            destructible.Hit(_damage);

            Destroy(gameObject);
        }
        
    }
}
