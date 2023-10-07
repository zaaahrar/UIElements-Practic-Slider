using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthBar))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private UnityEvent _addHealth;
    private UnityEvent _takeHealth;
    private HealthBar _healthRendering;
    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _damage = 10;

    public int Damage => _damage;
    public float Health => _health;
    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;

    private void Start()
    {
        _healthRendering = GetComponent<HealthBar>();
        _health = _maxHealth;
    }

    public void ChangeHealth(int value)
    {
        _health += value;
    }
}
