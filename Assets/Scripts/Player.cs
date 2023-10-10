using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _stepHealth = 10;

    public UnityAction<float> ChangingHealth;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void AddHealth()
    {
        if(_health < _maxHealth)
        {
            _health += _stepHealth;
            ChangingHealth?.Invoke(_health);
        }
    }

    public void TakeHealth()
    {
        if(_health > _minHealth)
        {
            _health -= _stepHealth;
            ChangingHealth?.Invoke(_health);
        }
    }
}
