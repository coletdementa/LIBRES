using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform atari;

    void Update(){
        gameObject.transform.position = new Vector3 (atari.transform.position.x, atari.transform.position.y, atari.transform.position.z);
    }
} 


