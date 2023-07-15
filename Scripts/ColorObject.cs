using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    private MeshRenderer mr;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(GameManager.instance.SetColorOfPlayers(mr.material));
            mr.enabled = false;
        }
    }
}
