using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator _animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Attack();
        }
    }
    void Attack()
    {
        //Plays animation
        _animator.SetTrigger("Attack");

        //Detects enemies in range of attack
       Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider Enemy in hitEnemies)
        {
            Enemy.GetComponent<Enemy_behavior>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        //To see the area of the hitbox
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    } 
}
