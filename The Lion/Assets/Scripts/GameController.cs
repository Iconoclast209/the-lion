using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int livesLeft = 3;
    public float playerRespawnTime = 3.0f;
    public GameObject player;
    public GameObject imageOops;
    public Shredder shredder;
    public LevelManager levelManager;
    public Vector3 playerSpawnPosition;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public Sprite yellow;
    public Sprite red;

    private bool playerIsDead = false;

    private void Awake()
    {
        //Find the Shredder and store a reference to it.
        shredder = FindObjectOfType<Shredder>();

        //Find the Level Manager and store a reference to it.
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void PlayerDies()
    {
        Debug.Log("PlayerDies function has been called in GameController");
        livesLeft--;
        //Update UI Objects
        UpdateSprites();
        imageOops.SetActive(true);
        player.GetComponent<PlayerMovement>().PausePlayerControl();

        if (livesLeft <= 0)
         {
            Invoke("EndGame", playerRespawnTime);
         }
        else
        {
            Invoke("ResetPlayer", playerRespawnTime);
        }
    }

    private void UpdateSprites()
    {
        if(livesLeft >= 3)
        {
            life3.GetComponent<Image>().sprite = yellow;
            life2.GetComponent<Image>().sprite = yellow;
            life1.GetComponent<Image>().sprite = yellow;
        }
        
        else if (livesLeft == 2)
        {
            life3.GetComponent<Image>().sprite = red;
        }
        else if (livesLeft == 1)
        {
            life2.GetComponent<Image>().sprite = red;
        }
        else if (livesLeft <= 0)
        {
            life1.GetComponent<Image>().sprite = red;
        }
    }

    public void ResetPlayer()
    {
        Debug.Log("Resetting Player.");
        //Move Player back to spawn position
        player.transform.position = playerSpawnPosition;
        ResetEnemies();
        //Re-enable player control.
        player.GetComponent<PlayerMovement>().ResumePlayerControl();
    }

    public void ResetEnemies()
    {
        //destroy then reload all enemies.
        Debug.Log("Resetting Enemies.");
        ResetOops();
    }

    public void ResetOops()
    {
        imageOops.SetActive(false);
        shredder.ResetPlayerIsAlive();
    }

    private void EndGame()
    {
        levelManager.LoadLevel(4);
    }

    public void WinGame()
    {
        Debug.Log("GameController.WinGame has been called.");
        Invoke("LoadWinScreen", 2.0f);
    }

    private void LoadWinScreen()
    {
        levelManager.LoadLevel(5);
    }
    

}
