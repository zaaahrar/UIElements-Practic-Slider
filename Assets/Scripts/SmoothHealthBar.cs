using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DisplayTextHealth))]
public class SmoothHealthBar : Bar
{
    private const float MaxDelta = 20;
    private DisplayTextHealth _textHealth;
    private Coroutine _currentCoroutine;

    private void Start()
    {
        _textHealth = GetComponent<DisplayTextHealth>();
        _slider.maxValue = _health.MaxHealth;
        _slider.value = _health.CurrentHealth;
        _textHealth.UpdateText(_health.CurrentHealth, _health.MaxHealth);
    }

    public override void OnHealthChanged(float newHealth)
    {
        if(_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeHealthAndText(newHealth));
    }

    private IEnumerator ChangeHealthAndText(float targetHealth)
    {
        while (_slider.value != targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, MaxDelta * Time.deltaTime);
            _textHealth.UpdateText(_slider.value, _health.MaxHealth);
            yield return null;
        }
    }
}
