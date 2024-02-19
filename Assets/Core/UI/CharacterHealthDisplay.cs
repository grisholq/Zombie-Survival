using TMPro;
using UnityEngine;
using Zenject;

public class CharacterHealthDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;

    [Inject] private Character _character;

    private void Start()
    {
        _character.Health.HealthChanged += DisplayHealth;
    }

    private void DisplayHealth(float health)
    {
        _healthText.text = ((int)(health)).ToString();
    }
}