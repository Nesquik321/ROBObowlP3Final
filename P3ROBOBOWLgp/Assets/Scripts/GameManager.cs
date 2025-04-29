using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController currentController;
    public CameraFollow cameraFollow;

   private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        TeammateController oldAI = currentController.GetComponent<TeammateController>();
        GameManager.Instance.SwitchControl(currentController, oldAI);
    }

    public void SwitchControl(PlayerController newController, TeammateController oldAI)
    {
        if (currentController != null)
        {
            currentController.SetControlled(false);

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
}
