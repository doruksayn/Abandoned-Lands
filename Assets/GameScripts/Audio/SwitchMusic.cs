using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : MonoBehaviour
{

    public AudioClip newTrack;
    private BGMusic theAM;
    
    void Start()
    {
        theAM = FindObjectOfType<BGMusic>();
        
    }

  
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            if(newTrack != null)
            theAM.ChangeBGM(newTrack);
        }
    }
}
