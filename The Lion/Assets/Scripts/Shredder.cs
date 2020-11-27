using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shredder : MonoBehaviour
{
    
    private GameController gameController;
    private PlayerMovement player;
    private bool playerIsAlive = true;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        gameController = FindObjectOfType<GameController>();
    }

    public void ResetPlayerIsAlive()
    {
        if(!playerIsAlive)
        {
            playerIsAlive = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(playerIsAlive)
            {
                Debug.Log("Shredder has detected player collision.");
                playerIsAlive = false;
                gameController.PlayerDies();
            }
        }
    }


}
