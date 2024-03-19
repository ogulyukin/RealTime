using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SaveSystem.FileSaverSystem
{
    public sealed class Saver
    {
        public void Save(IEnumerable<string> data, string filename)
        {
            if(File.Exists(filename))
            {
                File.Delete(filename);
            }
        
            try
            {
                StreamWriter sw = new StreamWriter(filename);
                foreach (var entry in data)
                {
                    sw.WriteLine(entry);
                }
                sw.Close();
            }
            catch(Exception e)
            {
                Debug.Log($"Exception: {e.Message}");
            }
        }
    }
}