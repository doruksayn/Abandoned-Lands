using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{

  [SerializeField] private Transform leftEdge;
  [SerializeField] private Transform rightEdge;
 

  [SerializeField] private Transform enemy;
  [SerializeField] private float speed;
  private Vector3 initScale;
  private bool moveLeft;

[SerializeField] private float enemyidleDuration;
  private float enemyidleTimer;

  [SerializeField] private Animator anim;

  private void Awake(){
      initScale = enemy.localScale;
  }
  private void OnDisable(){
      anim.SetBool("Move", false);
  }
  
  

  private void Update(){
      
      if(moveLeft){
          if(enemy.position.x >= leftEdge.position.x)
          MoveDirection(-1);
        
      else  
            Flip(); 
      }
      else{   
          if(enemy.position.x <= rightEdge.position.x)
          MoveDirection(1);
          else
              Flip();

          }    
      }

  private void Flip(){
      anim.SetBool("Move", false);
      enemyidleTimer += Time.deltaTime;

      if(enemyidleTimer > enemyidleDuration)

         moveLeft = !moveLeft;
  }

  private void MoveDirection(int direction){
      
      enemyidleTimer = 0;

      anim.SetBool("Move", true);

      enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);

      enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y);
       

  }
  
}
