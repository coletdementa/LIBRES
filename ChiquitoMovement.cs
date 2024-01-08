using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiquitoMovement : MonoBehaviour
{
    public float waitingCount;
    private float dirX;
    private float dirY;
    private float movementSpeed;
    public float jumpSpeed = 4;
    private float doubleJumpSpeed = 6;
    public float jumpCount;
    public float totalJumps = 1;
    public bool doubleJump;
    public float claws;

    public float wallCheckDistance;

    public float ledgeClimbX;
    public float ledgeClimbY;

    public bool reviving;
    public bool waking = true;
    public bool grounded;
    public bool linked;
    public bool ride;
    bool canJump;
    public bool faint;
    public bool ico;
    public bool isTouchingLedge;
    public bool isTouchingWall;
    public bool isTouchingClimbingWall;
    public bool canClimbLedge = false;
    public bool ledgeDetected;
    public bool waiting = false;
    public bool climbWall;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sp;
    private AudioSource source;

    public AudioClip jump;
    public AudioClip steps;
    public AudioClip call;

    private Vector2 ledgePosBot;
    private Vector2 ledgePos1;
    private Vector2 ledgePos2;
    public Vector3 respawnPoint;

    public GameObject grandote;

    public LayerMask whatIsGround;
    public LayerMask whatIsClimb;

    public Transform groundCheck;
    public Transform ledgeCheck;
    public Transform wallCheck;

    void Start(){
        rb = GetComponent<Rigidbody2D>(); 
        anim= GetComponent<Animator>();
        sp= GetComponent<SpriteRenderer>();
        source= GetComponent<AudioSource>();
        rb.bodyType = RigidbodyType2D.Static;
        waking = true;
        
    }

    void Update(){  
        dirX = Input.GetAxisRaw("Horizontal") * movementSpeed;
        dirY = Input.GetAxisRaw("Vertical") * movementSpeed;
        
        UpdateDirection();
        Animate();
        Jumping();
        Actions();
        ClimbLedge();
        Touching();
        Wait();
    }

    void Wake (){
        waking = false;
        faint = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void Die (){
        GameObject.Find("GameManager").SendMessage("Respawn");
    }

    void Revive (){
        anim.SetTrigger("reviving");
        faint = false;
        rb.bodyType = RigidbodyType2D.Static;
    }

    void Jumping(){

        if (Input.GetButtonDown("Jump") && grounded){
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);   
            source.clip = jump;
            source.Play();
            jumpCount -= 1;
        }

        if (Input.GetButtonDown("Jump") && !grounded && doubleJump){
            rb.AddForce(Vector2.up * doubleJumpSpeed, ForceMode2D.Impulse);   
            source.clip = jump;
            source.Play();
            jumpCount -= 1;
        }

        if (grounded && !Input.GetButton("Jump")){
            doubleJump = false;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y *0.5f);
        }

        if (linked && grounded){
            ride = true;
        }else{
            ride = false;
        }

        if (linked && !grounded){
            rb.velocity = new Vector2 (0, 4);
        }

        if (ride || ico){
            GameObject.Find("GameManager").SendMessage("Connected");
            movementSpeed = 2;
        }else{
            movementSpeed = 6;
            GameObject.Find("GameManager").SendMessage("Unconnected");
        }

        if (jumpCount >1){
            doubleJump = true;
        }else{
            doubleJump = false;
        }

        if (grounded){
            jumpCount = totalJumps;
        }
    }

    void Touching (){
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
        if (dirX == 0){
            wallCheckDistance = 0f;
        }

        isTouchingClimbingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsClimb);
        if (dirX == 0){
            wallCheckDistance = 0f;
        }

        isTouchingLedge = Physics2D.Raycast(ledgeCheck.position, transform.right, wallCheckDistance, whatIsGround);

        if(isTouchingWall && !isTouchingLedge && !ledgeDetected){
            ledgeDetected = true;
            ledgePosBot = wallCheck.position;
        }
    }

    void ClimbLedge (){
        if(ledgeDetected && !canClimbLedge){
            canClimbLedge = true;
        }

        if (canClimbLedge){
            rb.velocity = new Vector2 (0f,0f);
            rb.gravityScale = 0f;
        }
    }

    public void FinishLedgeClimb(){
        canClimbLedge = false;
        transform.position = new Vector2 (transform.position.x + ledgeClimbX, transform.position.y + ledgeClimbY);
        rb.gravityScale = 1;
        ledgeDetected = false;
    }

    void Actions(){
        if (isTouchingClimbingWall && claws == 1){
            rb.velocity = new Vector2 (dirX, dirY/2);
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt)){
            GameObject.Find("GameManager").SendMessage("Death");
        }
        ico = Input.GetKey(KeyCode.LeftControl);
        if (ico){
            GameObject.Find("GameManager").SendMessage("Ico");
        }
    }

    void Animate(){
        anim.SetFloat("velocityHorizontal", Mathf.Abs(dirX));
        anim.SetFloat("velocityVertical", rb.velocity.y);
        anim.SetBool("grounded", grounded);
        anim.SetBool("ride", ride);
        anim.SetBool("faint", faint);
        anim.SetBool("ico", ico);
        anim.SetBool("canClimbLedge", canClimbLedge);
        anim.SetBool("waiting", waiting);
        anim.SetBool("waking", waking);
        anim.SetBool("isTouchingWall", isTouchingClimbingWall);
    }

    void UpdateDirection(){
        if (dirX > 0){
            wallCheckDistance = 0.2f;
            sp.flipX = false;
            waitingCount = 0;
            ledgeClimbX = 0.5f;
        }
        if (dirX < 0){
            wallCheckDistance = -0.2f;
            sp.flipX = true;
            waitingCount = 0;
            ledgeClimbX = -0.5f;
        }
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void Wait(){
        if (dirX == 0 && !waiting){
            waitingCount  += Time.deltaTime;
        }
        if ( waitingCount >= 5 ){
            waitingCount = 0;
            waiting = true;
        }else{
            waiting = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "MovingPlatform"){
            this.transform.parent = other.transform;
        }
    }
    
    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "MovingPlatform"){
            this.transform.parent = null;
        }
    }

    private void OnDrawGizmos(){
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }
}
