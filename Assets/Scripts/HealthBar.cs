using UnityEngine;

public class HealthBar : Bar
{
    private void Start()
    {
        _slider.maxValue = _health.MaxHealth;
        _slider.value = _health.CurrentHealth;
    }

    public override void OnHealthChanged(float newHealth)
    {
        _slider.value = newHealth;
    }
}
