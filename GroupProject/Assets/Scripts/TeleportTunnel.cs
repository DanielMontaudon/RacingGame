using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTunnel : MonoBehaviour
{
    [SerializeField] private GameObject TeleDes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "car")
            other.transform.position = TeleDes.transform.position;
    }
}
