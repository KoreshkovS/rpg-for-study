using UnityEngine;
using Game.BaseEntity;
using System.Collections;
using System;

namespace Game.Player { 

public class Player : Entity
    {
        [SerializeField] private PlayerManaComponent _manaComponent; // чи треба серіалайз філд?
        [SerializeField] private PlayerMove _playerMove = null;
        [SerializeField] private PlayerAttack _playerAttack = null;
        [SerializeField] private float _hitDelay = 0;
        
       
        private Coroutine _coroutine = null;


        private void FixedUpdate() // для роботи з фізикою
        {
            _playerMove.Move();
            _playerMove.MoveInStair();
            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerMove.Jump();
            }
            _playerMove.CheckingGround();
            animator.SetBool("IsJump", _playerMove.IsGround);

            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Attack");
                StartIEAttack();
            }
            if (Input.GetButtonDown("Fire2") && _manaComponent.CurrentMana >= _playerAttack.SpellCost)
            {
               
                _playerAttack.ShootFireBall();
                _manaComponent.ChangeCurrentMana(_playerAttack.SpellCost);



            }

        }

        private void StartIEAttack()
        {
            _coroutine = StartCoroutine(IEAttack());
        }

        private IEnumerator IEAttack()
        {
            yield return new WaitForSeconds(_hitDelay);
            _playerAttack.Attack();
        }

        private void OnDestroy()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            
        }



      
    }
}