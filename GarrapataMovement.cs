using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarrapataMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Collider2D collide;

    public float distance;
    public float movementSpeed;
    public float jumpSpeed;

    public float jumpingTime;
    private float time;
    
    private float pointA;
    private float pointB;
    private Vector3 initialPos;

    private float direction = 1;

    private GameObject danger;
    private GameObject pray;

    private Animator anim;
    private AudioSource source;

    public AudioClip scream;

    public bool grounded;
    public bool notGrounded;

    void Start()
    {
        danger = GameObject.Find("Grandote");
        pray = GameObject.Find("Chiquito");

        anim= GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();  
        sr = GetComponent<SpriteRenderer>();
        collide = GetComponent<Collider2D>();
        
        initialPos = this.transform.position;
        pointA = initialPos.x + distance;
        pointB = initialPos.x - distance;  

        collide.isTrigger = false; 
    }

    void Update(){
        anim.SetBool("grounded", grounded);
        anim.SetBool("notGrounded", notGrounded);

    }

    void FixedUpdate(){
        Vector3 translate = new Vector3 (movementSpeed * direction,0,rb.velocity.y);
        transform.Translate(translate * Time.deltaTime);

        if ((gameObject.transform.position.x > pointA) || (gameObject.transform.position.x < pointB)){
            direction = direction * -1;
            sr.flipX = !sr.flipX;
        }

        time += Time.deltaTime;
            
        if (time >= jumpingTime){
                time = 0;
                Jump();
        }
    }

    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "Grandote"){
            source.Play();
            Destroy(gameObject);
            Afraid();
        }
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ground"){
            notGrounded = false;
            Collide();
        }
        if (other.gameObject.tag == "Exit"){
            Destroy(gameObject);
        }
    }
    void OnTriggerExit2D (Collider2D other){
         if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ground"){
            notGrounded = true;
            FreeMove();
         }
    }

    void OnCollisionEnter2D (Collision2D other){
        if (other.gameObject.tag == "Grandote"){
        }
    }

    void Jump (){
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }

    void Afraid (){
        source.clip = scream;
        source.Play();
        rb.AddForce(Vector2.right * 9, ForceMode2D.Impulse);
        movementSpeed = 0;
        jumpSpeed -= 5;
    }

    void Collide (){
        notGrounded = false;
        collide.isTrigger = false;
    }
    void FreeMove (){
        notGrounded = true;
        collide.isTrigger = true;
    }
}
