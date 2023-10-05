using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HealthRendering))]
public class Player : MonoBehaviour
{
    private float _health = 100;
    private int _maxHealth = 100;
    private int _minHealth = 0;

    private HealthRendering _healthRendering;

    public float Health => _health;
    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;

    private void Start()
    {
        _healthRendering = GetComponent<HealthRendering>();
        _health = _maxHealth;
    }

    public IEnumerator ChangeHealth(float finalHealth)
    {
        while (_health != finalHealth)
        {
            _health = Mathf.MoveTowards(_health, finalHealth, 10f * Time.deltaTime);
            _healthRendering.UpdateUIElements();

            yield return null;
        }
    }
}
