using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderAI : MonoBehaviour
{
    public DefenderType DefenderType;
    public Transform quaterback;
    public Transform[] receivers;
    public float speed = 4f;
    private Transform currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        if (DefenderType == DefenderType.ManMarker && receivers.Length > 0)
        {
            currentTarget = receivers[0];
        }
        else if (DefenderType == DefenderType.Rusher)
        {
            currentTarget = quaterback;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.playStarted) return;

        if(GameManager.Instance.ballPassed && GameManager.Instance.ballCarrier != null)
        {
            Vector3 target = GameManager.Instance.ballCarrier.position;
            MoveToward(GameManager.Instance.ballCarrier.position);
            RotateTowardsTarget(target);
            return;
        }

        switch (DefenderType)
        {
            case DefenderType.Rusher:
                RushQB();
                break;
            case DefenderType.ManMarker:
                FollowReceiver();
                break;
            case DefenderType.Safety:
                PatrolAndReact();
                break;
        }
    }

    void RushQB()
    {
        if (quaterback != null)
            MoveToward(quaterback.position);
    }

    void FollowReceiver()
    {
        if (currentTarget != null)
            MoveToward(currentTarget.position);
    }

    void PatrolAndReact()
    {
        Vector3 patrolPoint = new Vector3(0, 0, 10f);
        MoveToward(patrolPoint);
    }

    void MoveToward(Vector3 targetPos)
    {
        Vector3 direction = (targetPos - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void RotateTowardsTarget(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

}
