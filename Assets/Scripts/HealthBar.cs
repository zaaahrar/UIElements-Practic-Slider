using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private TMP_Text _healthText;

    private float _imaginaryHealth = 100;
    private float _maxDelta = 10;
    private float _finalHealth;

    private void Start()
    {
        _sliderHealth.maxValue = _imaginaryHealth;
        UpdateUIElements();
    }

    public void DrawAddedHealth(float health)
    {
        _finalHealth = health;
        StartCoroutine(DrawHealth());
    }

    public void DrawTakeHealth(float health)
    {
        _finalHealth = health;
        StartCoroutine(DrawHealth());
    }

    private IEnumerator DrawHealth()
    {
        while (_imaginaryHealth != _finalHealth)
        {
            _imaginaryHealth = Mathf.MoveTowards(_imaginaryHealth, _finalHealth , _maxDelta * Time.deltaTime);
            UpdateUIElements();

            yield return null;
        }
    }

    private void UpdateUIElements()
    {
        _sliderHealth.value = _imaginaryHealth;
        _healthText.text = $"Î×ÊÈ ÆÈÇÍÈ: {((int)_imaginaryHealth)}";
    }
}
