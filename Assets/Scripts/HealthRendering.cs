using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class HealthRendering : MonoBehaviour
{
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private TMP_Text _healthText;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
        _sliderHealth.maxValue = _player.MaxHealth;
        _sliderHealth.minValue = _player.MinHealth;
        UpdateUIElements();
    }

    public void UpdateUIElements()
    {
        _sliderHealth.value = _player.Health;
        _healthText.text = $"Î×ÊÈ ÆÈÇÍÈ: {((int)_player.Health)}";
    }
}
