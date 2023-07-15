using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    [SerializeField] private SpawnManager spawnManager;
    
    
    [Header("***** OBJECTS *****")]
    public GameObject player, spawnPlayer;
    public GameObject lastPlayer;
    public List<GameObject> players;
    public Finish finish;

    [Header("***** TIMES *****")]
    public float moveTimeDelay,colorDelayTime,spawnPlayerDelayTime;

    [Header("***** UI *****")] 
    [SerializeField]
    private GameObject operationPanel;
    [SerializeField]
    private GameObject resultPanel;
    [SerializeField] private TextMeshProUGUI resultText;

    [Header("***** OTHER *****")] 
    public int playerDamage;

    public bool isFinish;
    

    private void Start()
    {
        AddPlayer(player);
    }

    public void AddPlayer(GameObject player)
    {
        players.Add(player);
        lastPlayer = player;
    }

    public IEnumerator MovementOfSpawnPlayers(Vector3 pos)
    {
        for(int i=1; i<players.Count;i++)
        {
            yield return new WaitForSeconds(moveTimeDelay);
            try
            {
                var newPos = new Vector3(players[i].transform.position.x, players[i].transform.position.y, pos.z);
                players[i].transform.position = Vector3.Lerp(players[i].transform.position, newPos, 0.1f);
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
    }
    
    public IEnumerator SetColorOfPlayers(Material color)
    {
        for(int i=0; i<players.Count;i++)
        {
            yield return new WaitForSeconds(colorDelayTime);
            var meshRenderer = players[i].transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
            meshRenderer.material = color;
        }
    }

    public IEnumerator SpawnPlayers(int number)
    {
        
        if (number >= 0)
        {
            resultText.text = "+"+ number.ToString();
            for (int i = 0; i < number; i++)
            {
                var pos = lastPlayer.transform.position;  
                spawnManager.Spawn(pos);
                yield return new WaitForSeconds(spawnPlayerDelayTime);
            }
            
        }
        else
        {
            resultText.text = number.ToString();
            for (int i = 0; i < -number; i++)
            {
                var lastIndex = players.Count - 1;
                if (lastIndex >= 1)
                {
                    Destroy(lastPlayer);
                    lastPlayer = players[lastIndex - 1];
                    players.RemoveAt(lastIndex);
                    lastIndex = players.Count - 1;
                    yield return new WaitForSeconds(spawnPlayerDelayTime);
                }
                
            }  
        }


    }


    #region UI

    public void SetActiveOperationPanel(bool active)
    {
        operationPanel.SetActive(active);
    } 
    
    public void SetActiveResultPanel(bool active)
    {
        resultPanel.SetActive(active);
    }

    
    

    #endregion

    #region Finish

    public void CheckFinish()
    {
        if (finish.totalValue > 0)
        {
            if (players.Count > 0)
            {
                isFinish = false; // the game is still running
                return;
            }
           
            else if (players.Count == 0) 
            {
                isFinish = true; // the game is Finish and lose
                Lose();
                return;
            }
               
        }
        else if(finish.totalValue ==0)
        {
            isFinish = true;
            Win();
            return;// the game is Finish and win
        }

        isFinish = true;

    }

    public void Win()
    {
        foreach (var item in players)
        {
            var rb = item.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            SetAnimation(item);
        }
    }

    private void Lose()
    {
        Debug.Log("Lose");
    }

    private void SetAnimation(GameObject player)
    {
        var animator = player.GetComponent<Animator>();
            animator.SetBool("isWin",true);
    }
    

    #endregion
    



}
