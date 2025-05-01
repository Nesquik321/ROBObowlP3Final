using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Football : MonoBehaviour
{
    public float passForce = 10f;
    public Rigidbody rb;
    public PlayerController currentController;
    private Transform attachedTo = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (attachedTo != null)
        {
            transform.position = attachedTo.position;
            transform.rotation = attachedTo.rotation;
        }
    }

    public void AttachTo(Transform hand)
    {
        attachedTo = hand;
        rb.isKinematic = true;
        GameManager.Instance.ballCarrier = hand.parent;
    }

    public void Detach()
    {
        attachedTo = null;
        rb.isKinematic = false;
    }

    public void PassTo(Transform target, Transform targetHand)
    {
        Detach();

        Debug.Log("Passing to: " + target);
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * passForce;
        StartCoroutine(WaitForArrival(target, targetHand));
    }

    private System.Collections.IEnumerator WaitForArrival(Transform target, Transform hand)
    {
        while (Vector3.Distance(transform.position, target.position) > 1f)
        {
            yield return null;
        }

        AttachTo(hand);

        PlayerController newController = target.GetComponent<PlayerController>();
        if (newController != null)
        {
            GameManager.Instance.SwitchControl(newController);
            GameManager.Instance.SetBallCarrier(hand.root, true);
        }
    }

   
}
