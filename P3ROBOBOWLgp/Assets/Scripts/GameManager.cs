using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController startingPlayerController;
    public CameraFollow cameraFollow;

    private PlayerController currentController;
    public Transform ballCarrier;
    public bool ballPassed = false;

   private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        if(startingPlayerController != null)
        {
            SwitchControl(startingPlayerController);
        }
        else
        {
            Debug.LogError("Starting player controller not assigned in GameManager!");
        }
    }

    public void SwitchControl(PlayerController newController)
    {
        if (currentController != null)
        {
            currentController.SetControlled(false);

            TeammateController oldAI = currentController.GetComponent<TeammateController>();
            if (oldAI != null)
                oldAI.SetControlled(false);
        }

        currentController = newController;
        currentController.SetControlled(true);

        TeammateController newAI = newController.GetComponent<TeammateController>();
        if (newAI != null)
            newAI.SetControlled(true);

        if(cameraFollow != null)
        {
            cameraFollow.SetTarget(currentController.transform);
        }
    }

    public void SetBallCarrier(Transform newCarrier, bool isPassed = false)
    {
        ballCarrier = newCarrier;
        ballPassed = isPassed;
    }

    public void EndPlay()
    {
        Debug.Log("Player stopped! Defender made contact");

        Time.timeScale = 0f;
    }
}
