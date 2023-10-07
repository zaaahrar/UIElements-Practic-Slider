using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(HealthRendering))]
public class WorkingWithHealth : MonoBehaviour
{
    [SerializeField] Button _buttonAddHealth;
    [SerializeField] Button _buttonTakeHalth;

    private int _stepHealth = 10;
    private float _finalHealth;

    private Player _player;
    private HealthRendering _healthRendering;

    private void Start()
    {
        _player = GetComponent<Player>();
        _healthRendering = GetComponent<HealthRendering>();
    }

    private void OnEnable()
    {
        _buttonAddHealth.onClick.AddListener(AddHealthOnClick);
        _buttonTakeHalth.onClick.AddListener(TakeHealthOnClick);
    }

    private void OnDisable()
    {
        _buttonAddHealth.onClick.RemoveListener(AddHealthOnClick);
        _buttonTakeHalth.onClick.RemoveListener(TakeHealthOnClick);
    }

    public void AddHealthOnClick()
    {
        _finalHealth = _player.Health + _stepHealth;
        _player.AddHealth(_stepHealth);

        if (_finalHealth < _player.MaxHealth + 1)
        {
            StartCoroutine(_healthRendering.DrawHealth(_finalHealth));
        }
    }

    public void TakeHealthOnClick()
    {
        _finalHealth = _player.Health - _stepHealth;
        _player.TakeHealth(_stepHealth);

        if (_finalHealth > _player.MinHealth - 1)
        {
            StartCoroutine(_healthRendering.DrawHealth(_finalHealth));
        }
    }
}
