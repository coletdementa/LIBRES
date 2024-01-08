using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public ChiquitoMovement chiquitoScriptCharacter;
    public GrandoteMovement grandoteScriptCharacter;

    public GameObject link;

    void Start (){
    link = GameObject.Find("WildMount");      
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.isTrigger == false){
            chiquitoScriptCharacter.grounded = true;
            grandoteScriptCharacter.grounded = true;
        }  
        if(other.gameObject.tag == "WildMount" || other.gameObject.tag == "DoubleJump"){
            chiquitoScriptCharacter.linked = true;
            grandoteScriptCharacter.linked = true;
        }
        if(other.gameObject.tag == "Player"){
            chiquitoScriptCharacter.linked = true;
            grandoteScriptCharacter.linked = true;
        }
    }
    void OnTriggerExit2D(Collider2D other){
         if(other.isTrigger == false){
            chiquitoScriptCharacter.grounded = false;
            grandoteScriptCharacter.grounded = false;
        }
        if(other.gameObject.tag == "WildMount" || other.gameObject.tag == "DoubleJump"){
            chiquitoScriptCharacter.linked = false;
            grandoteScriptCharacter.linked = false;
        }
        if(other.gameObject.tag == "Player"){
            chiquitoScriptCharacter.linked = false;
            grandoteScriptCharacter.linked = false;
        }
    }
}
