using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGameTextController : MonoBehaviour
{
    public Sprite[] textBoxes;
    public float timeForText;
    public GameObject imageObject;
    public LevelManager levelManager;

    private int indexForTextBoxes = 0;
    private bool bullfrogKingIsSpeaking = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!bullfrogKingIsSpeaking)
        {
            if (other.CompareTag("Player"))
            {
                bullfrogKingIsSpeaking = true;
                //Pause Player Control
                Debug.Log("Pause Player Control.");
                PlayerMovement player = other.GetComponent<PlayerMovement>();
                player.PausePlayerControl();
                //Activate Bullfrog Text
                imageObject.SetActive(true);
                Invoke("ChangeText", timeForText);
            }
        }

    }

    private void ChangeText()
    {
        if (indexForTextBoxes + 1 < textBoxes.Length)
        {
            indexForTextBoxes++;
            Image image = imageObject.GetComponent<Image>();
            image.sprite = textBoxes[indexForTextBoxes];
            Invoke("ChangeText", timeForText);
        }
        else
        {
            imageObject.SetActive(false);
            //Load Menu
            levelManager.LoadLevel(1);
        }
    }

}
