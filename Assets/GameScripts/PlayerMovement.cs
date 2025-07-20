using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
[SerializeField] private float speed; 
[SerializeField] private AudioSource jumpSoundEffect;
[SerializeField] private AudioSource footStepEffect;
[SerializeField] private AudioSource attackSoundEffect;
[SerializeField] private AudioSource hurtEffect;
[SerializeField] private AudioSource dieEffect;
public Rigidbody2D body;
private Animator anim;
private bool grounded;
public ParticleSystem dust;
private bool facingRight = true;
private bool attack;
private float move;


    private void Awake(){

       //Reference for rigidbody and Animator.
       body = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       footStepEffect = GetComponent<AudioSource>();
       
      
   }
   
    private void Update(){
       
       move = Input.GetAxis("Horizontal");
       body.velocity = new Vector2(move * speed, body.velocity.y);
       
       
         if(move < 0 && facingRight){
           Flip();
           
       }
       else if (move > 0 && !facingRight){           
           Flip();
           
       }

        void Flip(){
           facingRight = !facingRight;
           transform.Rotate(0f, 180f, 0f);
           
           if(grounded){
               CreateDust();
           }
          
       }
       
         
        if(Input.GetKey(KeyCode.W) && grounded ||(Input.GetKey("up")) && grounded){
           Jump();
       }

       anim.SetBool("Run", move != 0);
       anim.SetBool("Grounded", grounded);

       }

     private void Jump(){
       CreateDust();
       body.velocity = new Vector2(body.velocity.x, 10);
       anim.SetTrigger("Jump");
       grounded = false;
       
   }

     private void OnCollisionEnter2D(Collision2D collision){
       if(collision.gameObject.tag == "Ground")
       CreateDust();
       grounded = true;
       
}
     private void CreateDust(){
        dust.Play();
    }

     public bool canAttack(){
         return move == 0 && grounded;
     }

     private void OnTriggerEnter2D(Collider2D collision) {
           if(collision.tag == "FallDetector") {
                FindObjectOfType<LevelManager>().Restart();      
               
           }
       
       }
       

     //Effect Sounds Part
     private void footStep(){
         footStepEffect.Play();
     }
     private void jumpSound(){
         jumpSoundEffect.Play();
     }
     private void attackSound(){
         attackSoundEffect.Play();
     }
     private void hurtSound(){
         hurtEffect.Play();
     }
     private void dieSound(){
         dieEffect.Play();
     }
  

    
  
   

            
        
    
  
 
}
