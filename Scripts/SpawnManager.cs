using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnPlayer;

    private void Start()
    {
        spawnPlayer = GameManager.instance.spawnPlayer;
    }

    public void Spawn(Vector3 pos)
    {
        var newPos = new Vector3(pos.x + 0.2f, pos.y, pos.z);
       var spawnObj = Instantiate(spawnPlayer, newPos, Quaternion.identity);
       spawnObj.transform.eulerAngles = new Vector3(0, -90, 0);
       var meshRenderer = GameManager.instance.player.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
       spawnObj.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material = meshRenderer.material;
       
       GameManager.instance.AddPlayer(spawnObj);
    }
}
