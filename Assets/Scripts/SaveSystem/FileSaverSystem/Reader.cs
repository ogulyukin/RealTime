using System;
using System.Collections.Generic;
using System.IO;

namespace SaveSystem.FileSaverSystem
{
    public sealed class Reader
    {
        private readonly string _filename;

        public Reader(string filename)
        {
            this._filename = filename;
        }

        public bool IsSaveFileExist()
        {
            return File.Exists(_filename);
        }

        public string[] Load()
        {
            var resultList = new List<string>();
            if (!IsSaveFileExist())
                return resultList.ToArray();
            try
            {
                StreamReader sr = new StreamReader(_filename);
                var line = sr.ReadLine();
                while (line != null)
                {
                    resultList.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.WriteLine("Loading success");
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return resultList.ToArray();
        }
    }
}