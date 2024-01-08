using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    private AudioSource source;

    void Start(){
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == ("Player")){
            source.Play();
        }
    } 

    void OnTriggerExit2D (Collider2D other){
        if (other.gameObject.tag == ("Player")){
            source.Stop();
        }
    }  
}
