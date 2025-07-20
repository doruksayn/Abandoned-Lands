using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
   [SerializeField] private Health playerHealth;
   [SerializeField] private Image totalHealthBar;
   [SerializeField] private Image currentHealthbar;



   private void Start(){

       totalHealthBar.fillAmount = playerHealth.healthCurrent /10;

   }

   private void Update(){

       currentHealthbar.fillAmount = playerHealth.healthCurrent /10;

   }
}
