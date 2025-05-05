using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PassIconController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, 0);
    public TextMeshProUGUI numberText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.forward = Camera.main.transform.forward;
        }
    }

    public void SetNumber(int number)
    {
        numberText.text = number.ToString();
    }
}
