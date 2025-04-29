using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammateController : MonoBehaviour
{
    public FootballPosition position;
    private bool isControlled = false;

    // Update is called once per frame
    void Update()
    {
        if (isControlled) return;

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

    public void SetControlled(bool control)
    {
        isControlled = control;
    }

    void RunRoute()
    {
        transform.Translate(Vector3.forward * 3f * Time.deltaTime);
    }

    void FollowQB()
    {
        GameObject qb = GameObject.FindWithTag("Quaterback");
        if(qb != null)
        {
            Vector3 followPosition = qb.transform.position - qb.transform.forward * 2f + qb.transform.right * 1.5f;
            transform.position = Vector3.Lerp(transform.position, followPosition, Time.deltaTime * 2f);
        }
    }

    void Block()
    {

    }

    void Idle()
    {

    }
}
