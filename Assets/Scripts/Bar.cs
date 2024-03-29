using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider _slider;
    [SerializeField] protected Health _health;

    private void Start()
    {
        _slider.maxValue = _health.MaxHealth;
        _slider.value = _health.CurrentHealth;
    }

    private void OnEnable()
    {
        _health.ChangingHealth += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.ChangingHealth -= OnHealthChanged;
    }

    public abstract void OnHealthChanged(float newHealth);
}
