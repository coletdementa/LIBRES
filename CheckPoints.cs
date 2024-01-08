using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{   
    public GameObject guardando;
    public GameObject self;

    void Start(){
        guardando.SetActive (false);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag.Equals("Player")){
            GameObject.Find("GameManager").SendMessage("NewRespawnPoint", transform.position);
            guardando.SetActive (true);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag.Equals("Player")){
            Destroy (gameObject);
        }
    }

    void SavedAnim(){
        guardando.SetActive (false);
    }
}
