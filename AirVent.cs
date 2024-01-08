using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirVent : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float push;

    public bool leftRight;
    public bool upDown;

    private bool left;
    private bool right;
    private bool up;
    private bool down;

    private float count;
    public float timer;

    public GameObject particleUp;
    public GameObject particleDown;
    public GameObject particleLeft;
    public GameObject particleRight;

    void Start(){
        particleUp.SetActive (false);
        particleDown.SetActive (false);
        particleLeft.SetActive (false);
        particleRight.SetActive (false);
    }
    void Update(){
        if (leftRight){
            LeftRight();
        }
        if (upDown){
            UpDown ();
        }
    }
    void LeftRight(){

        count += Time.deltaTime;
        if (count >= timer && !left){
            particleLeft.SetActive (true);
            particleRight.SetActive (false);
            count = 0;
            left = true;
            right = false;
        }
        if (count >= timer && left){
            particleLeft.SetActive (false);
            particleRight.SetActive (true);
            count = 0;
            left = false;
            right = true;
        }
    }

    void UpDown(){
        count += Time.deltaTime;
        if (count >= timer && !down){
            particleDown.SetActive (true);
            particleUp.SetActive (false);
            count = 0;
            up = false;
            down = true;
        }
        if (count >= timer && down){
            particleDown.SetActive (false);
            particleUp.SetActive (true);
            count = 0;
            up = true;
            down = false;
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == ("Player") && up == true){
            playerRb.AddForce(Vector2.up * push/4, ForceMode2D.Force);
        }
        if (other.gameObject.tag == ("Player") && down == true){
            playerRb.AddForce(Vector2.down * push/4, ForceMode2D.Force);
        }
        if (other.gameObject.tag == ("Player") && left == true){
            playerRb.AddForce(Vector2.left * push, ForceMode2D.Force);
        }
        if (other.gameObject.tag == ("Player") && right == true){
            playerRb.AddForce(Vector2.right * push, ForceMode2D.Force);
        }
    }
}
