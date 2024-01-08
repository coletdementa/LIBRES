using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Vector3 initPos;
    float pointA;
    float pointB;

    public float distance;
    public float velocity;
    public int direction;
    public bool active;

    void Start()
    {
        initPos = this.transform.position;
        pointA = initPos.x;
        pointB = initPos.x + distance;
    }

    void FixedUpdate()
    {
        if (active){
            Vector3 translate = new Vector3(velocity * direction * Time.deltaTime, 0, 0);
            transform.Translate(translate);
        }

        if (gameObject.transform.position.x > pointB){
            direction = direction * -1;
        }
        if (active){
            Vector3 translate = new Vector3(velocity * direction * Time.deltaTime, 0, 0);
            transform.Translate(translate);
        }

        if (gameObject.transform.position.x < pointA){
            direction = direction * -1;
        }
    }
}
