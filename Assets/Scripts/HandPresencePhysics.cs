using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;

    private Collider[] handColliders;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
        rb.position = target.position;
        rb.rotation = target.rotation;
    }

    public void EnableHandCollider()
    {
        foreach (var item in handColliders)
        {
            item.enabled = true;
        }
    }

    public void EnableColliderDelay(float delay)
    {
        Invoke("EnableHandCollider", delay);
    }

    public void DisableHandCollider()
    {
        foreach (var item in handColliders)
        {
            item.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree / Time.fixedDeltaTime) * Mathf.Deg2Rad;
    }
}
