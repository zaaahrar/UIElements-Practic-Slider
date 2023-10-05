using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class WorkingWithHealth : MonoBehaviour
{
    private int _healthVariable = 10;
    private float _finalHealth;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    public void AddHealth()
    {
        _finalHealth = _player.Health + _healthVariable;

        if (_finalHealth <= _player.MaxHealth && _finalHealth >= _player.MinHealth)
        {
            StartCoroutine(_player.ChangeHealth(_finalHealth));
        }
        else
            Debug.Log("Здоровье выше сотни подняться не может.");
    }

    public void TakeHealth()
    {
        _finalHealth = _player.Health - _healthVariable;

        if (_finalHealth <= _player.MaxHealth && _finalHealth >= _player.MinHealth)
        {
            StartCoroutine(_player.ChangeHealth(_finalHealth));
        }
        else
            Debug.Log("Здоровье ниже нуля опуститься не может.");
    }
}
