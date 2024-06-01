//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;

//public class CSVWriter : MonoBehaviour
//{
//    string filepath = "Assets/Resources/data.csv";
//    private Dictionary<string, Dictionary<string, string>> csvData;
//    private List<string> colNames;
//    private List<string> rowNames;
//    // Start is called before the first frame update

//    private void Awake()
//    {
//        csvData = new Dictionary<string, Dictionary<string, string>>();
//        colNames = new List<string>();
//        rowNames = new List<string>();
//    }
//    void Start()
//    {
//        //filename = Application.dataPath + "/data.csv";
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    public void WriteCSV(string colName, string rowName, string val)
//    {
//        Debug.Log("CALL CSV CCCCCCCCCCCCCCCCCCCCCCCCCCCCCC"); 
//        if (!csvData.ContainsKey(colName))
//        {
//            csvData[colName] = new Dictionary<string, string>();
//            colNames.Add(colName);
//        }
//        if (!rowNames.Contains(rowName))
//        {
//            rowNames.Add(rowName);
//        }
//        csvData[colName][rowName] = val;
//        SaveCSV();
//    }

//    private void SaveCSV()
//    {
//        using (StreamWriter writer = new StreamWriter(filepath, true))
//        {
//            // Write the header
//            writer.Write("RowName");
//            foreach (var colName in colNames)
//            {
//                writer.Write($",{colName}");
//            }
//            writer.WriteLine();

//            // Write the data rows
//            foreach (var rowName in rowNames)
//            {
//                writer.Write(rowName);
//                foreach (var colName in colNames)
//                {
//                    string value = csvData[colName].ContainsKey(rowName) ? csvData[colName][rowName] : "";
//                    writer.Write($",{value}");
//                }
//                writer.WriteLine();
//            }
//        }
//    }
//    }


using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVWriter : MonoBehaviour
{
    public string filepath = "Assets/Resources/data1.csv";

    public List<Dictionary<string, string>> ReadCSV() // function to read csv file data 
    {
        
        var data = new List<Dictionary<string, string>>(); // list of rows (all csv data )
        var lines = File.ReadAllLines(filepath);
        var headers = lines[0].Split(';'); // header row (first row)

        for (int i = 1; i < lines.Length; i++) // for each row from row1
        {
            var values = lines[i].Split(';');
            
                var rowDict = new Dictionary<string, string>();

            for (int j = 0; j < headers.Length; j++)
            {
                rowDict[headers[j]] = values[j];
                
            }

            data.Add(rowDict);
        }
       

        return data;
    }

    public void ModifyCSV(List<Dictionary<string, string>> data, string level, string columnName, string newValue) // function to modify a specific cell given its row and col 
    {
      
        foreach (var row in data)
        {
            if (row["level"] == level)
            {
                if (row.ContainsKey(columnName))
                {
                    row[columnName] = newValue;
                    break;
                }
            }
        }
    }

    public void WriteCSV(List<Dictionary<string, string>> data) // update csv file after updating data variable
    {
       
        var lines = new List<string>();
        var headers = new List<string>(data[0].Keys);
        lines.Add(string.Join(";", headers));

        foreach (var row in data)
        {
            var line = new List<string>();

            foreach (var header in headers)
            {
                line.Add(row[header]);
            }

            lines.Add(string.Join(";", line));
        }

        File.WriteAllLines(filepath, lines);
    }



}