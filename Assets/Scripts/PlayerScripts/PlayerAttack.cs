using Game.Items;
using UnityEngine;

public class PlayerAttack : BaseAttack
{
    [SerializeField] private Transform _attackPoint = null;
    [SerializeField] private float _attackRadius = 0;
    [SerializeField] private FireBall _fireBall = null;
    [SerializeField] private Transform _gun = null;
    [SerializeField] private int _spellCost = 0;


    public int SpellCost => _spellCost;

    private void Awake()
    {
        damage = PlayerDataStore.LoadDamage((int)damage);
    }
    public override void Attack()
    {
        base.Attack();
    }

    public void ShootFireBall()
    {
        var fireBall = Instantiate(_fireBall, _gun.position, _gun.rotation);
        fireBall.Throw(_gun);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_attackPoint.position, _attackRadius);
    }


   public void AddDamage(object[] arg)
    {
        damage += (int)arg[0];
        PlayerDataStore.SaveDamage((int)damage);
    }

    private void OnEnable()
    {
        EventBus.SubScribe(PotionType.DamagePotion, AddDamage);
    }

    private void OnDisable()
    {
        EventBus.UnSubscribe(PotionType.DamagePotion, AddDamage);
    }
}

