using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chains : MonoBehaviour
{
    public GameObject pressIcon;
    public GameObject chainMask;
    public bool E;
    public bool unchain;
    private AudioSource source;
    private Animator anim;

void Start (){

    anim= GetComponent<Animator>();
    source = GetComponent<AudioSource>();
    pressIcon.SetActive (false);
    chainMask.SetActive (false);
}

void Update(){

    anim.SetBool("unchain", unchain);
        
        if (Input.GetKeyDown("e") && E == true)
        {
            unchain = true;
            source.Play();
        }else{
            unchain = false;
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

public void FinishUnchain(){
    chainMask.SetActive (true);
    Destroy(gameObject);
}


}
