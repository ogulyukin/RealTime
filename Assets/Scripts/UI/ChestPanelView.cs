using UnityEngine;

namespace UI
{
    public class ChestPanelView : MonoBehaviour
    {
        [SerializeField] private GameObject chestPrefab;

        private void Awake()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        public ChestView AddNewChest(Sprite closed, Sprite opened)
        {
            var chest = Instantiate(chestPrefab, transform);
            var chestView = chest.GetComponent<ChestView>();
            chestView.InitChest(closed, opened);
            return chestView;
        }
    }
}
