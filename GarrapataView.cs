using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarrapataView : MonoBehaviour
{
    private AudioSource source;
    public GameObject self;

    void Start(){
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "Grandote"){
            self.SendMessage("Afraid");
            source.Play();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ground"){
            self.SendMessage("Collide");
        }
    }
    void OnTriggerExit2D (Collider2D other){
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ground"){
            self.SendMessage("FreeMove");
        }
    }
    void OnColissionEnter2D (Collision2D other){
        if (other.gameObject.tag == "Grandote"){
            source.Play();
            Destroy(gameObject);
        }
    }
}
