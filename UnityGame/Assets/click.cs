using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class click : MonoBehaviour
{
    // Start is called before the first frame update
    // reference action to perform 
    public InputActionProperty triggerAction;
    public InputActionProperty isTriggerAction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float triggerval = triggerAction.action.ReadValue<float>();
        //bool istrigger = isTriggerAction.action.ReadValue<bool>();
        //Debug.Log(triggerval);
        //Debug.Log(istrigger); 

    }
}
