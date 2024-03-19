using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using SaveSystem.Core;

namespace SaveSystem.FileSaverSystem
{
    [UsedImplicitly]
    public sealed class FileSystemSaverLoader : ISaverLoader
    {
        private readonly Reader _reader;
        private readonly Saver _saver;
        private readonly AesEncryptionProvider _encryptionProvider = new();

        public FileSystemSaverLoader()
        {
            _reader = new();
            _saver = new();
        }
        
        public void Save(List<Dictionary<string, string>> data, string filename)
        {
            var strList = new List<string>();
            foreach (var obj in data)
            {
                var str = JsonConvert.SerializeObject(obj);
                strList.Add(_encryptionProvider.AesEncryption(str));
            }
            _saver.Save(strList, filename);
        }

        public List<Dictionary<string, string>> Load(string filename)
        {
            var result = new List<Dictionary<string, string>>();
            if (!_reader.TryLoad(filename, out var loadedData ))
            {
                return result;
            }
            
            foreach (var data in loadedData)
            {
                var obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(_encryptionProvider.AesDecryption(data));
                if(obj != null) result.Add(obj);
            }
            return result;
        }
    }
}
