using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class ChestView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI chestNameText;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private Button button;
        [SerializeField] private Image closedChestImage;
        [SerializeField] private Image openedChestImage;

        public void SetChestName(string txt)
        {
            chestNameText.SetText(txt);
        }
        
        public void SetTimerText(string txt)
        {
            timerText.SetText(txt);
        }
        
        public void AddListener(UnityAction action)
        {
            button.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            button.onClick.RemoveListener(action);
        }

        public void OpenChest(bool flag)
        {
            closedChestImage.gameObject.SetActive(!flag);
            openedChestImage.gameObject.SetActive(flag);
        }

        public void InitChest(Sprite closed, Sprite opened)
        {
            closedChestImage.sprite = closed;
            openedChestImage.sprite = opened;
        }

        private void Awake()
        {
            OpenChest(false);
        }
    }
}
