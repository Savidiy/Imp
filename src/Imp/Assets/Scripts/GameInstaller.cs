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
        public InteractablesHolder _interactablesHolder;

        public override void InstallBindings()
        {
            Container.Bind<ImpSettings>().FromInstance(_impSettings).AsSingle();
            Container.Bind<ItemsSpriteData>().FromInstance(_itemsSpriteData).AsSingle();
            
            var impGameObject = Container.InstantiatePrefabForComponent<ImpGameObject>(_impPrefab, _startPoint);
            Container.Bind<ImpGameObject>().FromInstance(impGameObject);
            
            Container.Bind<IInteractablesHolder>().FromInstance(_interactablesHolder);
            Container.Bind<InventoryView>().FromInstance(_inventoryView);
            
            Container.BindInterfacesAndSelfTo<NearInteractableChecker>().AsSingle();
            Container.BindInterfacesAndSelfTo<ImpInteract>().AsSingle();
            Container.BindInterfacesAndSelfTo<ImpMove>().AsSingle();

            Container.BindInterfacesAndSelfTo<QuestGenerator>().AsSingle();
            Container.BindInterfacesAndSelfTo<QuestHolder>().AsSingle();
            
            Container.Bind<ItemsFactory>().To<ItemsFactory>().AsSingle();
            Container.Bind<ImpInventory>().To<ImpInventory>().AsSingle();
            Container.Bind<InventoryPresenter>().To<InventoryPresenter>().AsSingle().NonLazy();
        }
    }
}