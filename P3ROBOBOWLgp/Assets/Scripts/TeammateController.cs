using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammateController : MonoBehaviour
{
    public FootballPosition position;
    private bool isControlled = false;

    public void SetControlled(bool controlled)
    {
        isControlled = controlled;

        if (controlled)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
                rb.velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlled || !GameManager.Instance.playStarted) return;

        switch (position)
        {
            case FootballPosition.Receiver:
                RunRoute();
                break;
            case FootballPosition.RunningBack:
                FollowQB();
                break;
            case FootballPosition.Guard:
                Block();
                break;
            case FootballPosition.Quaterback:
                Idle();
                break;
        }

    }

    void RunRoute()
    {
        if (isControlled) return;
        transform.Translate(Vector3.forward * 3f * Time.deltaTime);
    }

    void FollowQB()
    {
        if (isControlled) return;

        GameObject qb = GameObject.FindWithTag("Quaterback");
        if(qb != null)
        {
            Vector3 followPosition = qb.transform.position - qb.transform.forward * 2f + qb.transform.right * 1.5f;
            transform.position = Vector3.Lerp(transform.position, followPosition, Time.deltaTime * 2f);
        }
    }

    void Block()
    {
        if (isControlled) return;
    }

    void Idle()
    {
        if (isControlled) return;
    }
}
