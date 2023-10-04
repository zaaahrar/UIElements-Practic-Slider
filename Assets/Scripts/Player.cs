using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private TMP_Text _healthText;

    private Coroutine _activeCorountine;
    private int _healthVariable = 10;
    private int _maxHealth = 100;
    private int _minHealth = 0;
    private float _finalHealth;

    private void Start()
    {
        _health = _maxHealth;
        _sliderHealth.maxValue = _maxHealth;
        _sliderHealth.minValue = _minHealth;
        UpdateUIElements();
    }

    public void AddHealth()
    {
        _finalHealth = _health + _healthVariable;

        if (_finalHealth <= _maxHealth && _finalHealth >= _minHealth)
        {
            StartCoroutine(ChangeHealth(_finalHealth));
        }
        else
            Debug.Log("Здоровье выше сотни подняться не может.");
    }

    public void TakeHealth()
    {
        _finalHealth = _health - _healthVariable;

        if (_finalHealth <= _maxHealth && _finalHealth >= _minHealth)
        {
            StartCoroutine(ChangeHealth(_finalHealth));
        }
        else
            Debug.Log("Здоровье ниже нуля опуститься не может.");
    }

    private void UpdateUIElements()
    {
        _sliderHealth.value = _health;
        _healthText.text = $"ОЧКИ ЖИЗНИ: {((int)_health)}";
    }

    private IEnumerator ChangeHealth(float finalHealth)
    {
        while (_health != finalHealth)
        {
            _health = Mathf.MoveTowards(_health, finalHealth, 10f * Time.deltaTime);
            UpdateUIElements();

            yield return null;
        }
    }
}
