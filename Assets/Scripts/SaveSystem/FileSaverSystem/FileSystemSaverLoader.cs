using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using SaveSystem.Core;

namespace SaveSystem.FileSaverSystem
{
    [UsedImplicitly]
    public sealed class FileSystemSaverLoader : ISaverLoader
    {
        private const string Filename = "MySaveGame.sav";
        private readonly Reader _reader;
        private readonly Saver _saver;
        private readonly AesEncryptionProvider _encryptionProvider = new();

        public FileSystemSaverLoader()
        {
            _reader = new Reader(Filename);
            _saver = new Saver(Filename);
        }
        
        public void Save(List<Dictionary<string, string>> data)
        {
            var strList = new List<string>();
            foreach (var obj in data)
            {
                var str = JsonConvert.SerializeObject(obj);
                strList.Add(_encryptionProvider.AesEncryption(str));
            }
            _saver.Save(strList.ToArray());
        }

        public List<Dictionary<string, string>> Load()
        {
            var result = new List<Dictionary<string, string>>();
            if (!_reader.IsSaveFileExist())
            {
                return result;
            }

            var loadedData = _reader.Load();
            foreach (var data in loadedData)
            {
                var obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(_encryptionProvider.AesDecryption(data));
                if(obj != null) result.Add(obj);
            }
            return result;
        }
    }
}
