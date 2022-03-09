using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;

    private Animator _animator;

    public float attackRange = 0.5f;
    public int attackDamage = 4;

  //  public float attackRate = 2f;
  //  float nextAttackTime = 0f;
    
    void Update()
    {
      //  if (Time.time >= nextAttackTime)
      //  {
           if (Input.GetButtonDown("Attack"))
           {
               Attack();
            //   nextAttackTime = Time.time + 1f / attackRange;
           } 
      //  }
    }

    public void Attack()
    {
        _animator = GetComponentInChildren<Animator>();
        _animator.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().ReduceHealth(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        return;{
            
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
