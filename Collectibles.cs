using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public GameObject pressIcon;
    public GameObject messageScreen;
    public bool E;
    private AudioSource source;


void Start (){
    source = GetComponent<AudioSource>();
    pressIcon.SetActive (false);
}

void Update(){
    if (Input.GetKeyDown("e") && E == true){
        source.Play();
        messageScreen.SetActive (true);
    }
}

void OnTriggerEnter2D (Collider2D other){
    if (other.gameObject.tag == "Player"){
        pressIcon.SetActive (true); 
        E = true;   
    }else{
        pressIcon.SetActive (false);
    }
}

void OnTriggerExit2D (Collider2D other){
    if (other.gameObject.tag == "Player"){
        pressIcon.SetActive (false);
        E = false;
    }
}

public void Done(){
    Destroy(gameObject);
}


}
