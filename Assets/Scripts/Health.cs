using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _currentHealth;

    private const int StepHealth = 10;
    private const float MinHealth = 0;

    public event Action<float> ChangingHealth;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void AddHealth()
    {
        _currentHealth += StepHealth;
        _currentHealth = Mathf.Clamp(_currentHealth, MinHealth, _maxHealth);
        ChangingHealth?.Invoke(_currentHealth);
    }

    public void TakeHealth()
    {
        _currentHealth -= StepHealth;
        _currentHealth = Mathf.Clamp(_currentHealth, MinHealth, _maxHealth);
        ChangingHealth?.Invoke(_currentHealth);
    }
}
