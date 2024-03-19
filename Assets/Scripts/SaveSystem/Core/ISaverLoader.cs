using System.Collections.Generic;

namespace SaveSystem.Core
{
    public interface ISaverLoader
    {
        public void Save(List<Dictionary<string, string>> data, string filename);
        public List<Dictionary<string, string>> Load(string filename);
        
    }
}
