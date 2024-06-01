using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class OnTrigger : MonoBehaviour
{
    public InputDevice _rightController;
    public InputDevice _leftController;
    public float triggerValue = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (_rightController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            Debug.Log("start trigger");
        }
    }

    private void InitializeInputDevices()
    {
        if (!_rightController.isValid)
        {
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, ref _rightController);
        }

        if (!_leftController.isValid)
        {
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref _leftController);
        }
    }
    private void InitializeInputDevice(InputDeviceCharacteristics inputCharacteristics, ref InputDevice inputDevice)
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(inputCharacteristics, devices);
        if (devices.Count > 0)
        {
            inputDevice = devices[0];
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (_rightController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            Debug.Log("update trigger");
        }

        if (!_rightController.isValid || !_leftController.isValid)
        {
            InitializeInputDevices();
        }
    }
    }
