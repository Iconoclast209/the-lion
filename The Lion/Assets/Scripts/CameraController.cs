using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float initialCameraYPosition = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Test to see if player is in middle of camera view or to the right.
        //if(player.transform.position.x > this.transform.position.x)
        //{
            float playerXPosition = player.transform.position.x;
            this.transform.position = new Vector3(playerXPosition,initialCameraYPosition,-10);
        //}
        
    }
}
