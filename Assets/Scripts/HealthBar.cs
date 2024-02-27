using UnityEngine;

public class HealthBar : Bar
{
    public override void OnHealthChanged(float newHealth)
    {
        _slider.value = newHealth;
    }
}
