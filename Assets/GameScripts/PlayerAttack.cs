using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = 10000;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Transform attackPoint;

    private void Awake(){
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update(){
        if (Input.GetKey(KeyCode.Space) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack(){

        anim.SetTrigger("Attack");

        cooldownTimer = 0;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Health>().TakeDamage(1);
            
        }

    }

    void OnDrawGizmosSelected(){

        if(attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
