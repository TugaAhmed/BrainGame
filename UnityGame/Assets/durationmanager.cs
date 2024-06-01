using Tobii.G2OM;
using UnityEngine;
using System.Collections.Generic;
using Unity.VRTemplate;

public class durationmanager : MonoBehaviour
{
    // Nested dictionary to store starting and ending times
    // for time serise
    public Dictionary<string, Dictionary<string, List<Vector2>>> timeDictionary = new Dictionary<string, Dictionary<string, List<Vector2>>>();

    public Dictionary<string, Dictionary<string, float>> objectFixationDuration = new Dictionary<string, Dictionary<string, float>>();

    private static float levelStartTime = 0f; // Timer to track the level start time
    private static float levelEndTime = 0f;   // Timer to track the level end time
    private static bool isLevelRunning = false;

    public StepManager currentlevelInst;

     //for time serise
    public void StoreTime(string level, string obj, float startTime, float endTime)
    {
        if (!timeDictionary.ContainsKey(level))
        {
            timeDictionary[level] = new Dictionary<string, List<Vector2>>();
        }

        if (!timeDictionary[level].ContainsKey(obj))
        {
            timeDictionary[level][obj] = new List<Vector2>();
        }

        timeDictionary[level][obj].Add(new Vector2(startTime, endTime));

        //Debug.Log(timeDictionary[level][obj]);
        //foreach (Vector2 vector2 in timeDictionary[level][obj])
        //{
        //    Debug.Log("VECTOR VVVVVVVVVVVVVVVVV" + obj + " " + vector2.x + " " + vector2.y);
        //}
    }

    // here fixation duration
    public void IncrementFixationDuration(GameObject obj, string lvlname, float duration)
    {
        CSVWriter csvWriter = new CSVWriter();
        var data = csvWriter.ReadCSV();

        string objectId = obj.name; //+ "_" + obj.GetInstanceID();

        if (!objectFixationDuration.ContainsKey(objectId))
        {
            objectFixationDuration[objectId] = new Dictionary<string, float>();
        }

        if (!objectFixationDuration[objectId].ContainsKey(lvlname))
        {

            objectFixationDuration[objectId][lvlname] = 0;

        }
        else
        {

            //objectFixationDuration[objectId][lvlname].Add(duration);
            objectFixationDuration[objectId][lvlname] += duration;

        }
        csvWriter.ModifyCSV(data, lvlname, objectId.ToString() +"_time" , objectFixationDuration[objectId][lvlname].ToString());
        csvWriter.WriteCSV(data);

        //Debug.Log("Fixation Duration for " + obj.name + ": " + objectFixationDuration[objectId][lvlname]);
    }

    // Stop the level timer

    // here is level total time 
    public void StopLevelTimer(string lvlname)
    {
        CSVWriter csvWriter = new CSVWriter();
        var data = csvWriter.ReadCSV();

        if (isLevelRunning)
        {
            levelEndTime = Time.time;
            isLevelRunning = false;

            csvWriter.ModifyCSV(data, lvlname, "total_time", (levelEndTime - levelStartTime).ToString());
            csvWriter.WriteCSV(data);
        }
    }

    public void StartLevelTimer()
    {
        if (!isLevelRunning)
        {
            levelStartTime = Time.time;
            isLevelRunning = true;
            //Debug.Log("start level"+levelStartTime);
        }
    }
}