using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchdownUI : MonoBehaviour
{
    public static TouchdownUI Instance;

    public GameObject touchdownText;
    public float displayTime = 2f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowTouchdown()
    {
        StartCoroutine(ShowTouchdownRoutine());
    }

    System.Collections.IEnumerator ShowTouchdownRoutine()
    {
        touchdownText.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        touchdownText.SetActive(false);
    }
}
