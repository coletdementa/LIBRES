using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
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
    if(other.gameObject.transform == achillesHeel.transform || other.gameObject.tag == "Grandote"){
        this.gameObject.SetActive (false);
    }
  }

      void Replace (){
        transform.position = pos;
        transform.rotation = rot;
    }
}

