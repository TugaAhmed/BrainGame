using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class dataanalysis : MonoBehaviour
{

    public void fixationCountsMeasure(Dictionary<string, Dictionary<string, int>> fixationCounts)
    {
        string countsPath = Application.persistentDataPath + "/FixationCounts";
        int maxlevel = 0;
        foreach (var counts in fixationCounts.Values) // for each object
        {
            foreach(var lvlKey in counts.Keys) // for each level : count 
            {
                int lvl;
                if(int.TryParse(lvlKey.Substring("Level ".Length), out lvl))
                {
                    if (lvl > maxlevel)
                    {
                        maxlevel = lvl;
                    }
                }
            }
        }

        using (StreamWriter writer = new StreamWriter(countsPath))
        {

            string header = "Object Name";
            for(int i = 1; i<=maxlevel; i++)
            {
                header += ", Level " + i ;
            }

            writer.WriteLine(header);

            foreach(var entry in fixationCounts)
            {

                string objectName = entry.Key;
                Dictionary<string, int> lvlCounts = entry.Value;

                string csvline = objectName;
                for(int i = 1; i<=maxlevel; i++)
                {
                    string levelKey = "Level " + i;
                    int cot = lvlCounts.ContainsKey(levelKey) ? lvlCounts[levelKey] : 0;
                    csvline += ", " + cot;
                }
                writer.WriteLine(csvline);

            }

        }

    }
}
