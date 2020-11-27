using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public float timeToMainMenu = 3.0f;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        Invoke("LoadMainMenu", timeToMainMenu);
    }

   void LoadMainMenu()
    {
        levelManager.LoadNextLevel();
    }
}
