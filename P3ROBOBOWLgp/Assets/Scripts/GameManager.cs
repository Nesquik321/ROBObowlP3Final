using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController currentController;

   private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        GameManager.Instance.SwitchControl(currentController);
    }

    public void SwitchControl(PlayerController newController)
    {
        if (currentController != null)
        {
            currentController.SetControlled(false);
        }

        currentController = newController;
        currentController.SetControlled(true);
    }
}
