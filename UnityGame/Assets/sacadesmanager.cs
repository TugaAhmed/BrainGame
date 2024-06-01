using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class saccadesmanager : MonoBehaviour
{
    public List<GameObject> gameObjectList = new List<GameObject>();

    public List<float> timesecond = new List<float>();

    public float timediff;

    public Dictionary<string, Dictionary<string, List<float>>> saccades = new Dictionary<string, Dictionary<string, List<float>>>();

    public void AddObj(GameObject obj)
    {

        gameObjectList.Add(obj);
        //Debug.Log("Added: " + obj.name);

    }

    public float Addtime(float value)
    {

        timesecond.Add(value);
        int index = timesecond.Count - 1;
        timediff = 0;

        if (index % 2 == 0 && index > 0)
        {
            // If the index is even, return the modified value

            timediff = value - timesecond[index - 1];

        }
        else if (index % 2 != 0)
        {

            //Debug.Log("Add Starttime of next object");
            timediff = 0;

        }

        return timediff;

    }

    public void IncrementSaccades(GameObject currentobj, float time, string lvlname)
    {
        CSVWriter csvWriter = new CSVWriter();
        var data = csvWriter.ReadCSV();

        int S_CurrentStepIndex = gameObjectList.Count - 1;

        if (S_CurrentStepIndex > 0 && gameObjectList[S_CurrentStepIndex - 1] != currentobj)
        {
            Vector3 previousobjpos = gameObjectList[S_CurrentStepIndex - 1].transform.position;
            Vector3 currentobjpos = currentobj.transform.position;

            float distance = Vector3.Distance(previousobjpos, currentobjpos);

            string object2object = gameObjectList[S_CurrentStepIndex - 1].name + " to " + currentobj.name;

            float velocity = distance / time;

            if (!saccades.ContainsKey(lvlname))
            {
                saccades[lvlname] = new Dictionary<string, List<float>>();
            }

            if (!saccades[lvlname].ContainsKey(object2object))
            {

                saccades[lvlname][object2object] = new List<float>();

            }

            saccades[lvlname][object2object].Add(velocity);

           // Debug.Log("The velocity from " + object2object + ": " + velocity);

            csvWriter.ModifyCSV(data, lvlname, "saccades", velocity.ToString());
            csvWriter.WriteCSV(data);
        }

    }
}