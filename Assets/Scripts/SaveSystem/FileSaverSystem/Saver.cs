using System;
using System.IO;
using UnityEngine;

namespace SaveSystem.FileSaverSystem
{
    public sealed class Saver
    {
        private readonly string _filename;

        public Saver(string filename)
        {
            this._filename = filename;
        }

        public void Save(string[] data)
        {
            if(File.Exists(_filename))
            {
                File.Delete(_filename);
            }
        
            try
            {
                StreamWriter sw = new StreamWriter(_filename);
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