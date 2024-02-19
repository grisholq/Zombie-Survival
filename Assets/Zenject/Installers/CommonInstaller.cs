using UnityEngine;
using Zenject;
using NaughtyAttributes;


public class CommonInstaller : MonoInstaller
{
    [SerializeField] private Character _character;
    [SerializeField] private GlobalInput _input;

    public override void InstallBindings()
    {
        Container.Bind<Character>().FromInstance(_character).AsSingle().NonLazy();
        Container.Bind<GlobalInput>().FromInstance(_input).AsSingle().NonLazy();
    }
}