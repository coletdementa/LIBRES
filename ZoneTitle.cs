using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTitle : MonoBehaviour
{
    public GameObject title;

    void Start(){
        title.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == ("Player")){
            title.SetActive(true);
            Destroy (gameObject);
        }
    }
}
