using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace SaveSystem.Core
{
    [UsedImplicitly]
    public sealed class SavingSystem
    {
        private const string Filename = "MySaveGame.sav"; //This will change to var and will managed outside this class
        private readonly ISaverLoader _saveLoader;
        private readonly List<ISaveAble> _saveAbles;

        public SavingSystem(ISaverLoader saveLoader, List<ISaveAble> saveAbles)
        {
            _saveLoader = saveLoader;
            _saveAbles = saveAbles;
        }

        public void LoadSceneData()
        {
            var loadedData = _saveLoader.Load(Filename);
            if (!loadedData.Any())
            {
                Debug.Log("SS: no data loaded!");
                return;
            }
            Debug.Log($"SS loaded: {loadedData.Count}");
            
            foreach (var saveAble in _saveAbles)
            {
                saveAble.RestoreState(loadedData);
            }
        }

        public void SaveSceneData()
        {
            var state = new List<Dictionary<string, string>>();
            
            foreach (var saveAble in _saveAbles)
            {
                state.AddRange(saveAble.CaptureState());
            }
            Debug.Log($"SS: captured {state.Count} entries");
            _saveLoader.Save(state, Filename);
        }
    }
}
