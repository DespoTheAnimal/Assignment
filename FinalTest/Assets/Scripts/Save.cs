using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

    public class Save 
    {

        string filename = Application.dataPath + "/test.csv";
        public List<Vector3> data = new List<Vector3>();
        public void WriteCSV()
        {
            if (data.Count > 0)
            {
                TextWriter tw = new StreamWriter(filename, false);
                tw.WriteLine("x; y; z");
                tw.Close();

                tw = new StreamWriter(filename, true);

                for (int i = 0; i < data.Count; i++)
                {
                    tw.WriteLine(data[i].x + ";"
                                 + data[i].y + ";" + data[i].z);
                }
                tw.Close();
            }
        }
    }
