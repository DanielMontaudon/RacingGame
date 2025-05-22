using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset = new Vector3(0, 2, -5);
    public float followSpeed = 10;
    public float lookSpeed = 35;

    private void Start()
    {
        if (!objectToFollow)
            objectToFollow = GameObject.FindGameObjectWithTag("car").transform;
    }
    public void LookAtTarget()
    {
        Vector3 lookDirection = objectToFollow.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, lookSpeed * Time.deltaTime);
    }

    public void MoveToTarget()
    {
        Vector3 targetPos = objectToFollow.position +
                            objectToFollow.forward * offset.z +
                            objectToFollow.right * offset.x +
                            objectToFollow.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }
}
