using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Football : MonoBehaviour
{
    public float passForce = 10f;

    public Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PassTo(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * passForce;
    }
}
