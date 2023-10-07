using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthRendering))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private UnityEvent _addHealth;
    private UnityEvent _takeHealth;
    private HealthRendering _healthRendering;
    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _damage = 10;

    public float Health => _health;
    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;

    private void Start()
    {
        _healthRendering = GetComponent<HealthRendering>();
        _health = _maxHealth;
    }

    public void TakeHealth()
    {
        if (_health > _minHealth)
        {
            _health -= _damage;
        }

        StartCoroutine(_healthRendering.DrawHealth(-_damage));
    }

    public void AddHealth()
    {
        if (_health < _maxHealth)
        {
            _health += _damage;
        }

        StartCoroutine(_healthRendering.DrawHealth(_damage));
    }
}
