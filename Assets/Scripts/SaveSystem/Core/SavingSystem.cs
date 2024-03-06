using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace SaveSystem.Core
{
    [UsedImplicitly]
    public sealed class SavingSystem
    {
        private readonly ISaverLoader _saveLoader;
        private readonly List<ISaveAble> _saveAbles;

        public SavingSystem(ISaverLoader saveLoader, List<ISaveAble> saveAbles)
        {
            _saveLoader = saveLoader;
            _saveAbles = saveAbles;
        }

        public bool LoadScene()
        {
            var loadedData = _saveLoader.Load();
            if (!loadedData.Any())
            {
                Debug.Log("SS: no data loaded!");
                return false;
            }
            Debug.Log($"SS loaded: {loadedData.Count}");
            
            foreach (var saveAble in _saveAbles)
            {
                saveAble.RestoreState(loadedData);
            }

            return true;
        }

        public void SaveScene()
        {
            var state = new List<Dictionary<string, string>>();
            
            foreach (var saveAble in _saveAbles)
            {
                state.AddRange(saveAble.CaptureState());
            }
            Debug.Log($"SS: captured {state.Count} entries");
            _saveLoader.Save(state);
        }
    }
}
