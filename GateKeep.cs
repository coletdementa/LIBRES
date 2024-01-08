using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKeep : MonoBehaviour
{
    public bool open = false;
    private Rigidbody2D rb;
    private Collider2D collide;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<Collider2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }
    void Update(){
        if (!open){
            GameObject.Find("GameManager").SendMessage("GrandoteNotAllowed");
        }else{
            GameObject.Find("GameManager").SendMessage("GrandoteAllowed");
        }
    }

    void Activate (){
        open = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        collide.isTrigger = true;
    }
}
