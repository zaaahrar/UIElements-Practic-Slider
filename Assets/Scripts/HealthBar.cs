using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private TMP_Text _healthText;

    private Player _player;
    private float _imaginaryHealth = 100;
    private float _maxDelta = 10;
    private float _finalHealth;

    private void Awake()
    {
        _sliderHealth.maxValue = _imaginaryHealth;
        _player = GetComponent<Player>();
        UpdateUIElements();
    }

    private void OnEnable()
    {
        _player.ChangingHealth += DrawHealthAction; 
    }

    private void OnDisable()
    {
        _player.ChangingHealth -= DrawHealthAction;
    }

    public void DrawHealthAction(float health)
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
