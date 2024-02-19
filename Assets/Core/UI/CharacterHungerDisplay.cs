using TMPro;
using System;
using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class CharacterHungerDisplay : MonoBehaviour
{
    [SerializeField] private List<HungerColorPair> _hungerColorPair;

    [SerializeField] private TextMeshProUGUI _hungerText;

    [Inject] private Character _character;

    private void Start()
    {
        _character.Hunger.HungerChanged += DisplayHunger;
    }

    private void DisplayHunger(float hunger)
    {
        _hungerText.color = GetTextColorByHungerState(_character.Hunger.State);
        _hungerText.text = ((int)(hunger)).ToString();
    }

    private Color GetTextColorByHungerState(HungerState state)
    {
        return _hungerColorPair.Find(i => i.State == state).Color;
    }
}

[Serializable]
public class HungerColorPair
{
    public Color Color;
    public HungerState State;
}