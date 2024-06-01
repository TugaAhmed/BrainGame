using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.XR;

public class pupildiameter : MonoBehaviour
{
    // Reference to the Text component to display pupil diameter
    public Text pupilDiameterText;

    // Start is called before the first frame update
    void Start()
    {
        // Start eye tracking
        TobiiXR.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("HELLLLLLLLLLLLLLLLLLLLo"); 
        TobiiXR_AdvancedEyeTrackingData eye = new TobiiXR_AdvancedEyeTrackingData();
        

        TobiiXR_AdvancedPerEyeData leftEye = eye.Left;
        TobiiXR_AdvancedPerEyeData rightEye = eye.Right;

        //if (leftEye.PupilDiameterValid && rightEye.PositionGuideValid) {

        float leftd = leftEye.PupilDiameter;
        float rightd = rightEye.PupilDiameter;

       // pupilDiameterText.text = "Left Pupil Diameter: " + leftd.ToString("F2") + "mm\n" +
        //                            "Right Pupil Diameter: " + rightd.ToString("F2") + "mm";
        //Debug.Log("left eye "+leftd);
       //Debug.Log("right eye "+rightd); 
        //}
    
        //else
        //{
          //  pupilDiameterText.text = "Pupil diameter data not valid";
        //}

        



    }

    // Stop eye tracking when the application is stopped or destroyed
    void OnDestroy()
    {
        TobiiXR.Stop();
    }
}
