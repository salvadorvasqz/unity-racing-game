using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    //Game controller
    public GameObject gameController;
    public GameController gameControl;
    // Start is called before the first frame update
    void Start()
    {
        //Get Game Controller component
        gameControl = gameController.GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Collision object
        GameObject collisionObject = other.gameObject;
        //Collision with checkpoint
        if (other.tag == "Checkpoint" && gameControl.checkpoints.Count > 0)
        {
            //Remove current checkpoint
            gameControl.checkpoints.RemoveAt(0);
            //Has more checkpoints
            if (gameControl.checkpoints.Count > 0)
            {
                //Enable next checkpoint
                gameControl.checkpoints[0].SetActive(true);
            }
            //No more checkpoints
            else
            {
                //Enable Finish
                gameControl.finish.SetActive(true);
            }
        }
        //Collision with finish
        if (other.tag == "Finish")
        {
            //Stop time
            gameControl.gameIsRunning = false;
            //Disable finish
            gameControl.finish.SetActive(false);
        }
    }
}
