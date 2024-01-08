using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float speed;
    public float zoomIn;
    public float zoomOut;

    public Vector3[] target;

    [SerializeField]
    private ChiquitoMovement chiquitoMovement;

    public Camera cam;

    void LateUpdate(){
        if (chiquitoMovement.linked){
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,zoomOut,speed);
        }else{
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,zoomIn,speed);
        }
    }
}
