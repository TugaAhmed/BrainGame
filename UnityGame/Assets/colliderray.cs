using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.VRTemplate;

public class colliderray : MonoBehaviour
{


    private XRBaseInteractor interactor; // Reference to the XR Interactor
    private GameObject currentHoveredObject; // Reference to the currently hovered object
    private float hoverStartTime; // Time when the hover started

    // Variable to store the hover duration
    private float hoverDuration;
    private const float hoverThreshold = 1.5f; // Threshold for hover duration in seconds

    // Variable to indicate if the condition is met
    private bool conditionMet = false;

    public StepManager _stepper;

    private Dictionary<string, int> testscore = new Dictionary<string, int>();

    private void Start()
    {


        // Get reference to the XR Interactor component
        interactor = GetComponent<XRBaseInteractor>();

        // Subscribe to the hover events
        interactor.onHoverEntered.AddListener(OnHoverEnter);
        interactor.onHoverExited.AddListener(OnHoverExit);

        _stepper = FindObjectOfType<StepManager>();
        if (_stepper == null)
        {
            //Debug.LogError("StepManager script not found in the scene.");
        }
    }

    private void Update()
    {
        // Check if the condition is met
        if (currentHoveredObject!=null)
        {
            if (!conditionMet && (currentHoveredObject.name == "a1" || currentHoveredObject.name == "a2" || currentHoveredObject.name == "a3" || currentHoveredObject.name == "a4"))
            {
                hoverDuration = Time.time - hoverStartTime;
                if (hoverDuration >= hoverThreshold)
                {
                    //Debug.Log("You choose this answer:" + currentHoveredObject.name);
                    conditionMet = true;
                    _stepper.scoring(currentHoveredObject);

                    _stepper.Next();
                }
            }
        }

    }

    private void OnHoverEnter(XRBaseInteractable interactable)
    {
        
        // Store reference to the hovered object
        currentHoveredObject = interactable.gameObject;
        hoverStartTime = Time.time; // Start the hover timer
        conditionMet = false; // Reset condition flag
        // Do something with the hovered object (e.g., highlight it)
        Debug.Log("Hovering over: " + currentHoveredObject.name);
    }

    private void OnHoverExit(XRBaseInteractable interactable)
    {
        // Clear reference to the hovered object
        currentHoveredObject = null;

        // Do something when the hover exits (e.g., remove highlight)
        Debug.Log("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX No longer hovering over any object");
    }
}
