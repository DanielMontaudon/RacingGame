using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameController;

    private void Awake()
    {
        if (!gameController)
            gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "car")
        {
            gameController.GetComponent<CountdownController>().EndTimer();
        }
    }
}
