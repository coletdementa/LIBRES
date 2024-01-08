using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float activationTime;

    public bool activated;
    public float time;

    Rigidbody2D rb;

    Vector3 pos;
    Quaternion rot;

    void Start(){

        activated = false;

        pos = transform.position;
        rot = transform.rotation;

        rb = gameObject.GetComponent <Rigidbody2D> ();    
        rb.bodyType = RigidbodyType2D.Static;
    }

    void Update(){
        if (activated == true){
            time += Time.deltaTime;
        }

        if (time >= activationTime){
                time = 0;
                activated = false;
                Fall();
            }
    }

    void Fall(){
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void OnCollisionEnter2D (Collision2D other){
        if (other.gameObject.tag == "Player"){
            activated = true;
        }
        if (other.gameObject.tag != "Player"){
            rb.mass = 100.0f;
        }
    }

    void Replace (){
        rb.bodyType = RigidbodyType2D.Static; 
        transform.position = pos;
        transform.rotation = rot;
    }
}
