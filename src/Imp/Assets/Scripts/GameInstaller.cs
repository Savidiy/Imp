using UnityEngine;
using Zenject;

namespace Imp
{
    internal sealed class GameInstaller : MonoInstaller
    {
        public GameObject _impPrefab;
        public Transform _startPoint;
        public ImpSettings _impSettings;
        public InteractablesHolder _interactablesHolder;

        public override void InstallBindings()
        {
            Container.Bind<ImpSettings>().FromInstance(_impSettings).AsSingle();
            
            var impGameObject = Container.InstantiatePrefabForComponent<ImpGameObject>(_impPrefab, _startPoint);
            Container.Bind<ImpGameObject>().FromInstance(impGameObject).AsSingle();
            
            Container.Bind<IInteractablesHolder>().FromInstance(_interactablesHolder).AsSingle();
            
            Container.BindInterfacesAndSelfTo<NearInteractableChecker>().AsSingle();
            Container.BindInterfacesAndSelfTo<ImpInteract>().AsSingle();
            Container.BindInterfacesAndSelfTo<ImpMove>().AsSingle();

            Container.Bind<ItemsFactory>().To<ItemsFactory>().AsSingle();
            Container.Bind<ImpInventory>().To<ImpInventory>().AsSingle();
        }
    }
}