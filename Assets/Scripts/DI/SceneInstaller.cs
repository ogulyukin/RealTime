using Chests;
using Rewards;
using SaveSystem.Core;
using SaveSystem.Data;
using SaveSystem.FileSaverSystem;
using SaveSystem.Tools;
using Tools;
using UI;
using UnityEngine;
using Zenject;

namespace DI
{
    public sealed class SceneInstaller : MonoInstaller
    {
        [SerializeField] private ChestPanelView chestPanelView;
        [SerializeField] private ChestsInstaller chestsInstaller;
        [SerializeField] private SavingSystemHelper savingSystemHelper;
        public override void InstallBindings()
        {
            Container.Bind<ChestPanelView>().FromInstance(chestPanelView);
            Container.BindInterfacesAndSelfTo<ChestManager>().AsSingle();
            Container.Bind<ChestsInstaller>().FromInstance(chestsInstaller);
            Container.Bind<RewardGiver>().AsSingle();
            SavingSystemBinding();
        }

        private void SavingSystemBinding()
        {
            Container.Bind<SavingSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<FileSystemSaverLoader>().AsSingle();
            Container.Bind<SavingSystemHelper>().FromInstance(savingSystemHelper);
            Container.BindInterfacesAndSelfTo<ChestSavingManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChestInstallerSavingManager>().AsSingle();
        }
    }
}