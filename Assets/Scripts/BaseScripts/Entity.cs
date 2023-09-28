using UnityEngine;

namespace Game.BaseEntity
{ 

public class Entity : MonoBehaviour
    {
        [SerializeField] private BaseHealthComponent _healthComponent;

        [SerializeField] protected Rigidbody2D rigidBody = null;
        [SerializeField] protected Animator animator = null;
        


        protected virtual void OnEnable()
        {
            _healthComponent.OnHealthNull += Dead;
        }

        protected virtual void OnDisable()
        {
            _healthComponent.OnHealthNull -= Dead;
        }

        public virtual void Dead()
        {

            Destroy(gameObject);
        }



    }


}
