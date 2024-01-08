using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    public GameObject roof;
    public float activationTime;

    public bool activated = false;
    public float time;

    public Collider2D collide;

    void Update(){
        if (activated == true){
            time += Time.deltaTime;
        }
        if (time >= activationTime){
                time = 0;
                activated = false;
                door.SendMessage("Activate");
                roof.SendMessage("Activate");
                UnderPressure ();
        }
    }

    void UnderPressure () {
        collide.isTrigger = true;
    }
    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Grandote"){
            activated = true;
        }
    }
}
