using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObjects : MonoBehaviour
{
      void Reset (){
        foreach (Transform child in transform){
        child.gameObject.SetActive (true);
        }
    }
}
