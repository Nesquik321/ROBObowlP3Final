using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.ballCarrier != null && other.transform == GameManager.Instance.ballCarrier)
        {
            GameManager.Instance.EndPlay();
        }
    }
}
