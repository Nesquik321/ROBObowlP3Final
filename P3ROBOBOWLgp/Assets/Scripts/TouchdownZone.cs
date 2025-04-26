using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchdownZone : MonoBehaviour
{
    public int touchdownPoints = 6;
    public float cooldownTime = 5f;

    private bool isOnCooldown = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOnCooldown)
        {
            Debug.Log("Touchdown!");
            ScoreManager.Instance.AddPoints(touchdownPoints);
            TouchdownUI.Instance.ShowTouchdown();
            StartCoroutine(StartCooldown());
        }

        System.Collections.IEnumerator StartCooldown()
        {
            isOnCooldown = true;
            yield return new WaitForSeconds(cooldownTime);
            isOnCooldown = false;
        }
    }
}
