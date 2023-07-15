using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    
    void Update()
    { Vector3 mousePosition = Input.mousePosition;
    
        
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            SetPlayerPos(hit.point);
        }
        
    }
    

    private void SetPlayerPos(Vector3 pos)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, pos.z);
        StartCoroutine(GameManager.instance.MovementOfSpawnPlayers(transform.position));
    }
}
