using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    private float currentHealth;
    private Animator anim;
    private bool dead;

    [Header("iFRAMES")]
    [SerializeField] private float inVulnerableDuration;
    [SerializeField] private float flashNumber;
    private SpriteRenderer spriteRend;
    [SerializeField] private AudioSource HearthEffect;



    public float healthCurrent{
        get{
            return currentHealth;
        }
        set{
            currentHealth = value;
        }
    }
   
    private void Awake(){

        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage){

        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        
        if(currentHealth > 0){

            anim.SetTrigger("Hurt");
            StartCoroutine(Invunerability());

           
        }
        else{
            if(!dead){
                
            anim.SetTrigger("Die");
            if(GetComponent<PlayerMovement>() != null)
            GetComponent<PlayerMovement>().enabled = false;
            
           

            if(GetComponentInParent<BossAI>() != null)
            GetComponentInParent<BossAI>().enabled = false;
            if(GetComponent<MeleeEnemy>() != null)
            GetComponent<MeleeEnemy>().enabled = false;
            
    

            
            dead = true;
            StartCoroutine(PlayerDeath());
            
            
                     
           }      
        }
    }
    
    public void HealthGain(float value){
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth + value);
        StartCoroutine(GetComponent<GainHealth>().HealthFlash());
        HealthSound();
        


        
    }

    IEnumerator PlayerDeath(){
        yield return new WaitForSeconds(4);
         FindObjectOfType<LevelManager>().Restart();
         }
    private IEnumerator Invunerability(){

        Physics2D.IgnoreLayerCollision(6, 7, true);
        for(int i = 0; i < flashNumber; i++){

            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(inVulnerableDuration / (flashNumber * 2)) ;
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(inVulnerableDuration / (flashNumber * 2)) ;

        }
        Physics2D.IgnoreLayerCollision(6, 7, false);


    }
     private void HealthSound(){
         HearthEffect.Play();
     }

   
}
