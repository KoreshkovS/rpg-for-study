using Game.BaseEntity;
using Game.Player;
using UnityEngine;

public class Skeleton : Entity
{
    [SerializeField] private EnemyMove _enemyMove = null;
    [SerializeField] private SkeletonAttack _sreletonAttack = null;
    [SerializeField] private int _deadScore = 0;


    private void Start()
    {
        _enemyMove.StartMove();
    }

    private void Update()
    {
        _enemyMove.Move();
        animator.SetFloat("Speed", _enemyMove.Speed);
    }

    public override void Dead()
    {
        base.Dead();
    }


    public void StartAttack()
    {
        _sreletonAttack.Attack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            _enemyMove.StopMove();
            animator.SetBool("IsAttack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            _enemyMove.StartMove();
            animator.SetBool("IsAttack", false);
        }
    }
}
