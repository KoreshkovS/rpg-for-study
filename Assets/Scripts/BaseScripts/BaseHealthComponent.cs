using System;
using UnityEngine;

public class BaseHealthComponent : MonoBehaviour, IDestructible
{
    public event Action OnHealthNull;
    public event Action<float, float> OnChangeHP;

    [SerializeField] protected float maxHealth = 0;

    protected float _health;

    protected virtual void Awake()
    {
        maxHealth = PlayerDataStore.LoadMaxHealth((int)maxHealth);
        _health = maxHealth;
    }

   


    public virtual void Hit(float damage)
    {
        if (_health <= 0)
        return;

        _health -= damage;
        OnChangeHP?.Invoke(_health, maxHealth);
        if (_health <= 0)
            OnHealthNull?.Invoke();
 
    }
}
