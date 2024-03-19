using System;
using System.Collections.Generic;
using System.IO;

namespace SaveSystem.FileSaverSystem
{
    public sealed class Reader
    {
        public bool IsSaveFileExist(string filename)
        {
            return File.Exists(filename);
        }

        public bool TryLoad(string filename, out IEnumerable<string> resultData)
        {
            resultData = null;
            var resultList = new List<string>();
            if (!IsSaveFileExist(filename))
            {
                return false;
            }
            
            try
            {
                StreamReader sr = new StreamReader(filename);
                var line = sr.ReadLine();
                while (line != null)
                {
                    resultList.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                resultData = resultList;
                Console.WriteLine("Loading success");
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return true;
        }
    }
}