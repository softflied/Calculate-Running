using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CameraStopPoint") && other.transform.name == "MainPlayer")
        {
            Camera.main.GetComponent<CameraFollow>().follow = false;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            var _finish = other.gameObject.GetComponent<Finish>();
            _finish.SetValue(GameManager.instance.playerDamage);
            this.gameObject.SetActive(false);
        }
    }
}
