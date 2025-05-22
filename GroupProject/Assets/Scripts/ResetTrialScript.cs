using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetTrialScript : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRot;

    private void Start()
    {
        startPos = gameObject.transform.position;
        startRot = gameObject.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown("r") == true)
        {
            ResetTrial();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // If it's not working make sure the tag is set on land
        if (collision.gameObject.tag == "Land")
        {
            ResetTrial();
        }
    }

    private void ResetTrial()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
    }
}
