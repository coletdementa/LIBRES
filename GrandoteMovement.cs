using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandoteMovement : MonoBehaviour
{
    float dirX;
    public float movementSpeed;
    public Rigidbody2D rb;

    public bool grounded;
    public bool linked;
    public bool ride;
    public bool scared;

    private Animator anim;
    private SpriteRenderer sp;

    public GameObject companion;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        sp= GetComponent<SpriteRenderer>();
    }

    void Update(){
        dirX = Input.GetAxisRaw("Horizontal") * movementSpeed;
        anim.SetFloat("GrandoteVelocityHorizontal", Mathf.Abs(dirX));
        anim.SetBool("ride", ride);
        anim.SetBool("scared", scared);

        if (scared){
            ride = false;
            linked = false;
        }

        if (!ride){
            movementSpeed = 0;    
        }else{
            movementSpeed = 2;
        }

        if (linked && grounded){
            ride = true;
        }else{
            ride = false;
        }
        
        UpdateDirection();
    }

    void UpdateDirection(){
        if (dirX > 0 && ride == true){
            sp.flipX = false;
        }
        if (dirX < 0 && ride == true){
            sp.flipX = true;
        }
    }

    void FixedUpdate () {
        rb.velocity = new Vector2(dirX, 0);
    }
}

