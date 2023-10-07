using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private int _maxHealth = 100;
    private int _minHealth = 0;

    public float Health => _health;
    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeHealth(int value)
    {
        if (_health > _minHealth)
        {
            _health -= value;
        }

    }

    public void AddHealth(int value)
    {
        if (_health < _maxHealth)
        {
            _health += value;
        }
    }
}
