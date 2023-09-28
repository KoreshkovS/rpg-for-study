using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _hitCollider = null;
    [SerializeField] protected float damage = 0;

    public virtual void Attack()
    {
        Vector3 hitPosition = transform.TransformPoint(_hitCollider.offset);
        Collider2D[] hits = Physics2D.OverlapCircleAll(hitPosition, _hitCollider.radius);

        for (int i = 0; i < hits.Length; i++)
        {
            if (!GameObject.Equals(hits[i].gameObject, gameObject))
            {
                IDestructible destructible = hits[i].gameObject.GetComponent<IDestructible>();
                if (destructible != null)
                {
                    destructible.Hit(damage);
                }
            }
        }
    }
}
