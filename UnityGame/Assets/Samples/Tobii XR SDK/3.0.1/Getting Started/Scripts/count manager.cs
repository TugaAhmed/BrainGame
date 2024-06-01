//using UnityEngine;
//using System.Collections.Generic;

//public class countmanager : MonoBehaviour
//{
//    public Dictionary<string, int> _highlightCounts = new Dictionary<string, int>();

//    public void IncrementHighlightCount(GameObject obj)
//    {
//        string objectId = obj.name; //+ "_" + obj.GetInstanceID();

//        if (!_highlightCounts.ContainsKey(objectId))
//        {
//            _highlightCounts[objectId] = 1;
//        }
//        else

//        {
//            _highlightCounts[objectId]++;
//        }

//        Debug.Log("Highlight Count for " + obj.name + ": " + _highlightCounts[objectId]);
//    }
//    public Dictionary<string, int> getCountDict()
//    {
//        return _highlightCounts; 
//    }
//}

using UnityEngine;
using System.Collections.Generic;

public class countmanager : MonoBehaviour
{
    public Dictionary<string, Dictionary<string, int>> _highlightCounts = new Dictionary<string, Dictionary<string, int>>();

    // here is the count 
    public void IncrementHighlightCount(GameObject obj, string lvlname)
    {
        CSVWriter csvWriter = new CSVWriter();
        var data = csvWriter.ReadCSV();

        string objectId = obj.name; //+ "_" + obj.GetInstanceID();

        if (!_highlightCounts.ContainsKey(objectId))
        {
            _highlightCounts[objectId] = new Dictionary<string, int>();
        }

        if (!_highlightCounts[objectId].ContainsKey(lvlname))
        {

            _highlightCounts[objectId][lvlname] = 1;

        }
        else
        {

            _highlightCounts[objectId][lvlname]++;

        }

        Debug.Log("Highlight Count for " + obj.name + ": " + _highlightCounts[objectId][lvlname]);
        csvWriter.ModifyCSV(data, lvlname, objectId.ToString() + "_count", _highlightCounts[objectId][lvlname].ToString());
        csvWriter.WriteCSV(data);
    }
}
