using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GrandoteMovement grandoteScriptCharacter;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == ("Grandote")){
        grandoteScriptCharacter.scared = true;
        }else{
            grandoteScriptCharacter.scared = false;
        }
    }
}
