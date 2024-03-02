using Chests;
using Tools;
using UI;
using UnityEngine;
using Zenject;

namespace DI
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private ChestPanelView chestPanelView;
        [SerializeField] private ChestsInstaller chestsInstaller;
        public override void InstallBindings()
        {
            Container.Bind<ChestPanelView>().FromInstance(chestPanelView);
            Container.BindInterfacesAndSelfTo<ChestManager>().AsSingle();
            Container.Bind<ChestsInstaller>().FromInstance(chestsInstaller);
        }
    }
}