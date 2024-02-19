using UnityEngine;
using Zenject;
using NaughtyAttributes;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private Joystick _joystick;

    public override void InstallBindings()
    {
        Container.Bind<Joystick>().FromInstance(_joystick).AsSingle().NonLazy();
    }

    [Button]
    private void FindDependencies()
    {
        _joystick = FindObjectOfType<Joystick>(true);
    }
}