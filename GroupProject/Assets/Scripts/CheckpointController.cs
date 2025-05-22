using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    
    public GameObject[] checkpoints;
    private int[] cp;

    public bool ignoreFinishLine = true;
    //public bool lapComplete;
    public bool finished;

    public int currentLap=0;
    public int totalLaps=3;

    public int currentCheckpoints = 0;
    public int totalCheckpoints=5;

    // Start is called before the first frame update
    void Start()
    {
        if (!gameController)
            gameController = GameObject.FindGameObjectWithTag("GameController");
        clearCheckpoints();
    }

    // Update is called once per frame
    void Update()
    {
        //insert your code here to update UI components (or whatever u wanna do)!
    }

    private void OnTriggerEnter(Collider other)
    {
        for(int i=0;i<checkpoints.Length;i++)
        {
            if(checkpoints[i].GetComponent<BoxCollider>()==other)
            {
                //Debug.Log("Checkpoint tag hit: " + other.gameObject.tag);
                CheckpointHit(other);
            }
        }
    }

    public void CheckpointHit(Collider o)
    {
        //Debug.Log("Checkpoint tag hit: " + o.gameObject.tag);

        int checkpointLocation = GetCheckpointOrder(o);
        //Debug.Log("Required checkpoint position = " + checkpointLocation);

        if (IsInOrder(checkpointLocation))
        {
            cp[checkpointLocation]=1;
            currentCheckpoints++;
            Debug.Log("Checkpoint #" + currentCheckpoints + " passed! Total Checkpoints per lap = " + totalCheckpoints);
            if (currentCheckpoints >= totalCheckpoints)
            {
                currentLap++;
                if (currentLap > totalLaps)
                {
                    Debug.Log("Finished!"); //put code here for when you finish the race
                    currentCheckpoints = 0;
                    currentLap = 0;
                    clearCheckpoints();
                    finished = true;
                    runAtFinish();
                }
                else
                {
                    Debug.Log("Lap #" + currentLap + "! Completed laps needed = " + totalLaps);
                }
                clearCheckpoints();
                currentCheckpoints = 0;
            }
        }
        
        
    }

    private int GetCheckpointOrder(Collider o)
    {
        for(int i=0;i<checkpoints.Length;i++)
        {
            if(o.gameObject.CompareTag(checkpoints[i].gameObject.tag))
            {
                return i;
            }
        }
        return -1;
    }

    public bool IsInOrder(int cLoc) //https://answers.unity.com/questions/953506/detection-ontriggerenter-on-the-child-in-parent-sc.html
    {
        for (int i = 0; i < cp.Length; i++)
        {
            if(cLoc==i && cp[i]==1)
            {
                //Debug.Log("Checkpoint #"+(cLoc+1)+" already visited!");
                return false;
            }
            if(cp[i]!=1 && (i<cLoc || i>cLoc))
            {
                //Debug.Log("Skipped checkpoint!");
                if (currentLap == 0)
                    currentLap++;
                return false;
            }
            else if(i==cLoc && cp[i] == 0)
            {
                //Debug.Log("Checkpoint is in order!");
                break;
            }
        }
        return true;
    }

    public void clearCheckpoints()
    {
        cp = new int[totalCheckpoints];
        for (int i = 0; i < cp.Length; i++)
        {
            cp[i] = 0;
        }
    }

    public void runAtFinish()
    {
        gameController.GetComponent<CountdownController>().EndTimer();
    }
}
