using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainHealth : MonoBehaviour
{

    public float inVulnerableDuration;
    public float flashNumber;
    public SpriteRenderer spriteRend;
    public IEnumerator HealthFlash(){

        for(int i = 0; i < flashNumber; i++){

            spriteRend.color = new Color(0,1,0, 0.5f);
            yield return new WaitForSeconds(inVulnerableDuration / (flashNumber * 2)) ;
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(inVulnerableDuration / (flashNumber * 2)) ;

        }
        


    }
}
