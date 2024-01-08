using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
  Vector3 pos;
  Quaternion rot;
  public GameObject achillesHeel;
  public ChiquitoMovement chiquitoScriptCharacter;

  void Start (){
    pos = transform.position;
    rot = transform.rotation;
    this.gameObject.SetActive (true);
  }

  void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.tag == ("Player")){
      GameObject.Find("GameManager").SendMessage("Death");
    }
    if(other.gameObject.transform == achillesHeel.transform){
      this.gameObject.SetActive (false);
    }
  }

      void Replace (){
        transform.position = pos;
        transform.rotation = rot;
    }
}
