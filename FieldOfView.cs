using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public ChiquitoMovement scriptCharacter;
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.isTrigger == false){
            scriptCharacter.grounded = true;
        }  
        if(other.gameObject.tag == "Grandote" || other.gameObject.tag == "DoubleJump"){
            scriptCharacter.linked = true;
        }
        if(other.gameObject.tag == "Player"){
            scriptCharacter.linked = true;
        }
    }
    void OnTriggerExit2D(Collider2D other){
         if(other.isTrigger == false){
            scriptCharacter.grounded = false;
        }
        if(other.gameObject.tag == "Grandote" || other.gameObject.tag == "DoubleJump"){
            scriptCharacter.linked = false;
        }
        if(other.gameObject.tag == "Player"){
            scriptCharacter.linked = false;
        }
    }
}
