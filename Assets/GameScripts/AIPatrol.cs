using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{

  [SerializeField] private Transform leftEdge;
  [SerializeField] private Transform rightEdge;

  [SerializeField] private Transform enemy;
  [SerializeField] private float speed;
  private Vector3 initScale;
  private bool moveLeft;

  private void Awake(){
      initScale = enemy.localScale;
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
      moveLeft = !moveLeft;
  }

  private void MoveDirection(int direction){

      enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);

      enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y);

  }
}
