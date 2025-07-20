using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
   [SerializeField] private float attackCooldown;
   [SerializeField] private float colliderDistance;
   [SerializeField] private float range;
   [SerializeField] private float upRange;
   [SerializeField] private float damage;
   [SerializeField] private BoxCollider2D boxCollider;
   [SerializeField] private LayerMask playerLayer;
   [SerializeField] private AudioSource dieEffect;
   [SerializeField] private AudioSource hurtEffect;
   private float cooldownTimer = 100000;

   private Animator anim;
   private Health playerHealth;
   private BossAI bossPatrol;

   private void Awake(){
       anim = GetComponent<Animator>();
       bossPatrol = GetComponentInParent<BossAI>();
   }

   private void Update(){

       cooldownTimer += Time.deltaTime;

       if(PlayerInSight()){
           if(cooldownTimer >= attackCooldown){
               
               cooldownTimer = 0;
               anim.SetTrigger("meleeAttack");
               
               
       }

       }
       if (bossPatrol != null)
       bossPatrol.enabled = !PlayerInSight();
       }
   
   
       private bool PlayerInSight(){
           RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right *range *transform.localScale.x * colliderDistance,
           new Vector3(boxCollider.bounds.size.x *range, boxCollider.bounds.size.y *upRange, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

           if(hit.collider != null){
               playerHealth = hit.transform.GetComponent<Health>();
           }

           return hit.collider != null;
       }

       private void OnDrawGizmos(){
           Gizmos.color = Color.red;
           Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right *range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x *range, boxCollider.bounds.size.y *upRange, boxCollider.bounds.size.z));
       }

       private void PlayerDamage(){
           if(PlayerInSight()){
               playerHealth.TakeDamage(damage);
           }
       }
       private void dieSound(){
         dieEffect.Play();
     }
       private void hurtSound(){
         hurtEffect.Play();
     }
}

       
   

