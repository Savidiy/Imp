using UnityEngine;
using Zenject;

namespace Imp
{
    internal sealed class GameInstaller : MonoInstaller
    {
        public GameObject _impPrefab;
        public Transform _startPoint;
        public ImpSettings _impSettings;
        public ItemsSpriteData _itemsSpriteData;
        public InventoryView _inventoryView;
        public InteractInfo _interactInfoPrefab;
        public QuestScrollView _questScrollView;
        public AnimationDataProvider _animationDataProvider;

        public override void InstallBindings()
        {
            Container.Bind<ImpSettings>().FromInstance(_impSettings).AsSingle();
            Container.Bind<ItemsSpriteData>().FromInstance(_itemsSpriteData).AsSingle();
            Container.Bind<AnimationDataProvider>().FromInstance(_animationDataProvider).AsSingle();

            var impGameObject = Container
                .InstantiatePrefabForComponent<ImpGameObject>(_impPrefab, _startPoint.position, Quaternion.identity, null);
            Container.Bind<ImpGameObject>().FromInstance(impGameObject);

            var interactInfo = Container
                .InstantiatePrefabForComponent<InteractInfo>(_interactInfoPrefab);
            Container.Bind<InteractInfo>().FromInstance(interactInfo);

            Container.Bind<InventoryView>().FromInstance(_inventoryView);
            Container.Bind<QuestScrollView>().FromInstance(_questScrollView);

            Container.BindInterfacesAndSelfTo<InteractInfoDrawer>().AsSingle();
            Container.BindInterfacesAndSelfTo<InteractablesHolder>().AsSingle();
            Container.BindInterfacesAndSelfTo<NearInteractableChecker>().AsSingle();
            Container.BindInterfacesAndSelfTo<ImpInteract>().AsSingle();
            Container.BindInterfacesAndSelfTo<ImpMove>().AsSingle();

            Container.BindInterfacesAndSelfTo<CameraToObjectObserver>().AsSingle();

            Container.BindInterfacesAndSelfTo<QuestGenerator>().AsSingle();
            Container.BindInterfacesAndSelfTo<QuestHolder>().AsSingle();
            Container.BindInterfacesAndSelfTo<QuestScrollPresenter>().AsSingle();

            Container.Bind<ItemsFactory>().To<ItemsFactory>().AsSingle();
            Container.Bind<ImpInventory>().To<ImpInventory>().AsSingle();
            Container.Bind<InventoryPresenter>().To<InventoryPresenter>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<AnimationPlayerTicker>().AsSingle();
            Container.BindInterfacesAndSelfTo<AnimationPlayer>().AsTransient();
            Container.BindInterfacesAndSelfTo<ImpAnimator>().AsSingle().NonLazy();
        }
    }
}