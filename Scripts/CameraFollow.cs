using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followObject;
    public float followTime;
    public float lerpTime;
    public bool follow;

    private void Start()
    {
        follow = true;
    }


    private void FixedUpdate()
    {
        if (follow)
        {
            transform.position = new Vector3( followObject.transform.position.x+7,transform.position.y,
                Vector3.Lerp(transform.position,followObject.transform.position,lerpTime).z
            );
        }
       
    }

  /*  public void SetCamPos(float number)
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(transform.position.x
            +number,transform.position.y,transform.position.z), lerpTime);
    }*/
}
