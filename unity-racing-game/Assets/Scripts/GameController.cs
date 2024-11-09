using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//UI libraries
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    //Time is running
    public bool gameIsRunning = true;
    //Time Control
    public TextMeshProUGUI timeText;
    private float currentTime;
    private int seconds;
    private int minutes;
    //checkpoints
    public List<GameObject> checkpoints;
    public GameObject finish;

    // Start is called before the first frame update
    void Start()
    {
        initializeCheckpoints();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsRunning)
        {
            stopWatch();
        }
    }
    void stopWatch()
    {
        //Add seconds
        currentTime += Time.deltaTime;
        seconds = Mathf.RoundToInt(currentTime);
        if (seconds >= 60)
        {
            seconds = 0;
            currentTime = 0;
            minutes++;
        }
        //Set time on screen
        timeText.SetText(minutes.ToString("D2") + ":" + seconds.ToString("D2"));
    }

    void initializeCheckpoints()
    {
        //Get all checkpoints
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint").ToList<GameObject>();
        finish = GameObject.FindGameObjectWithTag("Finish");
        //Track has checkpoints
        if (checkpoints.Count > 0)
        {
            //Sort checkpoints
            checkpoints.Sort(sortCheckpoints);
            //Hide all checkpoints
            foreach (var checkpoint in checkpoints)
                checkpoint.SetActive(false);
            //Show first checkpoint
            checkpoints[0].SetActive(true);
        }
        //Hide finish
        finish.SetActive(false);
    }

    //Sort checkpoints by name
    int sortCheckpoints(GameObject a, GameObject b)
    {
        return int.Parse(a.name) - int.Parse(b.name);
    }
}
