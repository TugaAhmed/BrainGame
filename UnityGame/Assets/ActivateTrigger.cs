using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTrigger : MonoBehaviour
{
    public GameObject rightRay;
    public InputActionProperty rightActivate;
    // Start is called before the first frame update
    void Start()
    {
        //rightRay.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        //rightRay.SetActive(rightActivate.action.ReadValue<float>() > 0.1f);
        bool isTriggerClicked = rightActivate.action.ReadValue<float>() > 0.0f;
        float triggerValue = rightActivate.action.ReadValue<float>();
        Debug.Log("Trigger value: " + triggerValue);

        // Activate or deactivate the rightRay based on trigger button click
        //rightRay.SetActive(isTriggerClicked);
        if (isTriggerClicked)
        {
            Debug.Log("on click");
        }
    }
}
