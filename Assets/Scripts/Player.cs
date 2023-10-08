using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthBar))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _stepHealth = 10;

    private HealthBar _healthBar;

    private void Start()
    {
        _healthBar = GetComponent<HealthBar>();
        _health = _maxHealth;
    }

    public void AddHealth()
    {
        if(_health < _maxHealth)
        {
            _health += _stepHealth;
            _healthBar.DrawAddedHealth(_health);
        }
    }

    public void TakeHealth()
    {
        if(_health > _minHealth)
        {
            _health -= _stepHealth;
            _healthBar.DrawTakeHealth(_health);
        }
    }
}
