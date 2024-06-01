//using Tobii.G2OM;
//using UnityEngine;

//// Monobehaviour which implements the "IGazeFocusable" interface, meaning it will be called on when the object receives focus
//public class fixationcomponents : MonoBehaviour, IGazeFocusable
//{
//    private static readonly int _baseColor = Shader.PropertyToID("_BaseColor");
//    public Color highlightColor = Color.red;
//    public float animationTime = 0.1f;

//    private Renderer _renderer;
//    private Color _originalColor;
//    private Color _targetColor;
//    private float _highlightStartTime;
//    private float _highlightDuration;
//    private countmanager _highlightCounter;
//    private CSVWriter cSVWriter;

//    // The method of the "IGazeFocusable" interface, which will be called when this object receives or loses focus
//    public void GazeFocusChanged(bool hasFocus)
//    {
//        // If this object received focus, start the highlight timer and fade the object's color to highlight color
//        if (hasFocus)
//        {
//            _highlightStartTime = Time.time;
//            _highlightCounter.IncrementHighlightCount(gameObject);
//            //foreach (var pair in _highlightCounter.getCountDict())
//            //{
//             //   Debug.Log("+++++++++++++++++++++++++++ Object ID: " + pair.Key + ", Times Looked: " + pair.Value);
//             //   cSVWriter.WriteCSV(pair.Key, '1'.ToString(), pair.Value.ToString());

//           // }
//            _targetColor = highlightColor;
//        }
//        // If this object lost focus, stop the highlight timer and fade the object's color to its original color
//        else
//        {
//            _highlightDuration = Time.time - _highlightStartTime;
//            _targetColor = _originalColor;

//            // Display the fixation duration in the console
//            Debug.Log("Fixation Duration: " + gameObject.name + _highlightDuration.ToString("F2") + " seconds");

//        }
//    }

//    private void Start()
//    {
//        _renderer = GetComponent<Renderer>();
//        _originalColor = _renderer.material.color;
//        _targetColor = _originalColor;
//        cSVWriter = FindAnyObjectByType<CSVWriter>();

//        _highlightCounter = FindObjectOfType<countmanager>();
//        if (_highlightCounter == null)
//        {
//            Debug.LogError("HighlightCounter script not found in the scene.");
//        }
//    }

//    private void Update()
//    {
//        // This lerp will fade the color of the object
//        if (_renderer.material.HasProperty(_baseColor)) // new rendering pipeline (lightweight, hd, universal...)
//        {
//            _renderer.material.SetColor(_baseColor, Color.Lerp(_renderer.material.GetColor(_baseColor), _targetColor, Time.deltaTime * (1 / animationTime)));
//        }
//        else // old standard rendering pipline
//        {
//            _renderer.material.color = Color.Lerp(_renderer.material.color, _targetColor, Time.deltaTime * (1 / animationTime));
//        }
//    }
//}


//using Tobii.G2OM;
//using UnityEngine;
//using Unity.VRTemplate;

//// Monobehaviour which implements the "IGazeFocusable" interface, meaning it will be called on when the object receives focus
//public class fixationcomponents : MonoBehaviour, IGazeFocusable
//{
//    private static readonly int _baseColor = Shader.PropertyToID("_BaseColor");
//    //public Color highlightColor = Color.red;
//    public float animationTime = 0.1f;

//    private Renderer _renderer;
//    private Color _originalColor;
//    //private Color _targetColor;
//    private float _highlightStartTime;
//    private float _highlightEndTime;
//    private float _highlightDuration;
//    public StepManager currentlevelInst;
//    private countmanager _highlightCounter;
//    private durationmanager durationtracker;
//    //private saccadesmanager saccadestracker;
//    //private long _lastGazeTimestamp;
//    //private long _currentGazeTimestamp;

//    // The method of the "IGazeFocusable" interface, which will be called when this object receives or loses focus
//    public void GazeFocusChanged(bool hasFocus)
//    {
//        // If this object received focus, start the highlight timer and fade the object's color to highlight color
//        if (hasFocus)
//        {
//            _highlightStartTime = Time.time;
//            _highlightCounter.IncrementHighlightCount(gameObject, currentlevelInst.GetCurrentLevelName());
//            //_targetColor = highlightColor;

//            // Calculate time difference when object turns back to original color
//            ////_currentGazeTimestamp = GetCurrentTimestamp();
//            //long gazeDuration = _currentGazeTimestamp - _lastGazeTimestamp;
//            //saccadestracker.IncrementSaccades(durationtracker.GetCurrentLevelName(), gazeDuration);
//        }
//        // If this object lost focus, stop the highlight timer and fade the object's color to its original color
//        else
//        {
//            _highlightEndTime = Time.time;
//            _highlightDuration = _highlightEndTime - _highlightStartTime;
//            durationtracker.IncrementFixationDuration(gameObject, currentlevelInst.GetCurrentLevelName(), _highlightDuration);
//            durationtracker.StoreTime(currentlevelInst.GetCurrentLevelName(), gameObject.name, _highlightStartTime, _highlightEndTime); // for time sereise
//            //_targetColor = _originalColor;

//            // Record timestamp when object turns red
//            //_lastGazeTimestamp = GetCurrentTimestamp();
//            // Record timestamp when object turns back to original color
//            //_lastGazeTimestamp = _currentGazeTimestamp;

//        }
//    }

//    private void Start()
//    {
//        _renderer = GetComponent<Renderer>();
//        _originalColor = _renderer.material.color;
//        //_targetColor = _originalColor;

//        _highlightCounter = FindObjectOfType<countmanager>();
//        durationtracker= FindObjectOfType<durationmanager>();
//        currentlevelInst = FindObjectOfType<StepManager>();
//        //saccadestracker = FindObjectOfType<durationmanager>();
//        if (_highlightCounter == null)
//        {
//            Debug.LogError("HighlightCounter script not found in the scene.");
//        }
//        if (durationtracker == null)
//        {
//            Debug.LogError("duration manager script not found in the scene.");
//        }
//        //if (saccadestracker == null)
//        //{
//        //    Debug.LogError("Saccades manager script not found in the scene.");
//        //}
//        if (currentlevelInst == null)
//        {
//            Debug.LogError("Step Manager script not found in the scene.");
//        }
//        durationtracker.StartLevelTimer();

//    }

//    private void Update()
//    {
//        // This lerp will fade the color of the object
//        //if (_renderer.material.HasProperty(_baseColor)) // new rendering pipeline (lightweight, hd, universal...)
//        //{
//        //    _renderer.material.SetColor(_baseColor, Color.Lerp(_renderer.material.GetColor(_baseColor), _targetColor, Time.deltaTime * (1 / animationTime)));
//        //}
//        //else // old standard rendering pipline
//        //{
//        //    _renderer.material.color = Color.Lerp(_renderer.material.color, _targetColor, Time.deltaTime * (1 / animationTime));
//        //}
//    }

//    private long GetCurrentTimestamp()
//    {
//        // Return current timestamp (in microseconds)
//        return (long)(Time.realtimeSinceStartup * 1000000);

//    }

//}

using Tobii.G2OM;
using UnityEngine;
using Unity.VRTemplate;
using Tobii.XR;

// Monobehaviour which implements the "IGazeFocusable" interface, meaning it will be called on when the object receives focus
public class fixationcomponents : MonoBehaviour, IGazeFocusable
{
    private static readonly int _baseColor = Shader.PropertyToID("_BaseColor");
    //public Color highlightColor = Color.red;
    public float animationTime = 0.1f;

    private Renderer _renderer;
    private Color _originalColor;
    //private Color _targetColor;
    private float _highlightStartTime;
    private float _highlightEndTime;
    private float _highlightDuration;
    public StepManager currentlevelInst;
    private countmanager _highlightCounter;
    private durationmanager durationtracker;
    private saccadesmanager saccadestracker;
    private blinkingmanager blinkstracker;

    private float timedifference = 0;

    // The method of the "IGazeFocusable" interface, which will be called when this object receives or loses focus
    public void GazeFocusChanged(bool hasFocus)
    {
        // If this object received focus, start the highlight timer and fade the object's color to highlight color
        if (hasFocus)
        {

            _highlightStartTime = Time.time;
            _highlightCounter.IncrementHighlightCount(gameObject, currentlevelInst.GetCurrentLevelName());
            //_targetColor = highlightColor;

            //compute timedifference

            saccadestracker.AddObj(gameObject);
            timedifference = saccadestracker.Addtime(_highlightStartTime);

            if (timedifference != 0)
            {
                saccadestracker.IncrementSaccades(gameObject, timedifference, currentlevelInst.GetCurrentLevelName());
            }

        }

        // If this object lost focus, stop the highlight timer and fade the object's color to its original color
        else
        {

            _highlightEndTime = Time.time;
            timedifference = saccadestracker.Addtime(_highlightEndTime);
            _highlightDuration = _highlightEndTime - _highlightStartTime;
            durationtracker.IncrementFixationDuration(gameObject, currentlevelInst.GetCurrentLevelName(), _highlightDuration);
            durationtracker.StoreTime(currentlevelInst.GetCurrentLevelName(), gameObject.name, _highlightStartTime, _highlightEndTime); // for time sereise
            //_targetColor = _originalColor;

        }
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
        //_targetColor = _originalColor;

        _highlightCounter = FindObjectOfType<countmanager>();
        durationtracker = FindObjectOfType<durationmanager>();
        currentlevelInst = FindObjectOfType<StepManager>();
        saccadestracker = FindObjectOfType<saccadesmanager>();
        blinkstracker = FindObjectOfType<blinkingmanager>();
        //if (_highlightCounter == null)
        //{
        //    Debug.LogError("HighlightCounter script not found in the scene.");
        //}
        //if (durationtracker == null)
        //{
        //    Debug.LogError("duration manager script not found in the scene.");
        //}
        //if (saccadestracker == null)
        //{
        //    Debug.LogError("Saccades manager script not found in the scene.");
        //}
        //if (currentlevelInst == null)
        //{
        //    Debug.LogError("Step Manager script not found in the scene.");
        //}
        //if (blinkstracker == null)
        //{
        //    Debug.LogError("Blinking Manager script not found in the scene.");
        //}
        durationtracker.StartLevelTimer();

    }

    private void Update()
    {
        var eyeTrackingData = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);

        if (eyeTrackingData.GazeRay.IsValid)
        {
            bool leftEyeClosed = eyeTrackingData.IsLeftEyeBlinking;
            bool rightEyeClosed = eyeTrackingData.IsRightEyeBlinking;

            if (leftEyeClosed && rightEyeClosed && currentlevelInst != null && blinkstracker != null)
            {
                blinkstracker.IncrementBlinks(currentlevelInst.GetCurrentLevelName());
                // Perform actions based on blink detection
            }
        }
        // This lerp will fade the color of the object
        //if (_renderer.material.HasProperty(_baseColor)) // new rendering pipeline (lightweight, hd, universal...)
        //{
        //    _renderer.material.SetColor(_baseColor, Color.Lerp(_renderer.material.GetColor(_baseColor), _targetColor, Time.deltaTime * (1 / animationTime)));
        //}
        //else // old standard rendering pipline
        //{
        //    _renderer.material.color = Color.Lerp(_renderer.material.color, _targetColor, Time.deltaTime * (1 / animationTime));
        //}
    }

}