using System.Collections;
using System;
using Zenject;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour, IDamagable
{
    public CharacterAnimator Animator;
    public CharacterMover Mover;
    public CharacterRotator Rotator;
    public CharacterRoll Roll;
    public CharacterInput Input;
    public Health Health;
    public Hunger Hunger;

    public void Damage(float damage)
    {
        Health.Damage(damage);
    }
}