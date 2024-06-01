using UnityEngine;
using System.Collections.Generic;

public class blinkingmanager : MonoBehaviour
{
    public Dictionary<string, int> blinkingCounts = new Dictionary<string, int>();

    // here is the count 
    public void IncrementBlinks(string lvlname)
    {
        CSVWriter csvWriter = new CSVWriter();
        var data = csvWriter.ReadCSV();

        if (!blinkingCounts.ContainsKey(lvlname))
        {

            blinkingCounts[lvlname] = 1;

        }
        else
        {

            blinkingCounts[lvlname]++;

        }

        //Debug.Log("Blinks Count for " + lvlname + ": " + blinkingCounts[lvlname]);

        csvWriter.ModifyCSV(data, lvlname, "blinkes", blinkingCounts[lvlname].ToString());
        csvWriter.WriteCSV(data);

    }
}

