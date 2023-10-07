using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Button _buttonAddHealth;
    [SerializeField] private Button _buttonTakeHalth;

    private float _imaginaryHealth;
    private float _maxDelta = 10;
    private Player _player;
    private float _finalHealth;

    private void Start()
    {
        _player = GetComponent<Player>();

        _imaginaryHealth = _player.MaxHealth;
        _sliderHealth.maxValue = _player.MaxHealth;
        _sliderHealth.minValue = _player.MinHealth;

        UpdateUIElements();
    }

    private void OnEnable()
    {
        _buttonAddHealth.onClick.AddListener(AddHealth);
        _buttonTakeHalth.onClick.AddListener(TakeHealth);
    }

    private void OnDisable()
    {
        _buttonAddHealth.onClick.RemoveListener(AddHealth);
        _buttonTakeHalth.onClick.RemoveListener(TakeHealth);
    }

    public IEnumerator DrawHealth()
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

    private void AddHealth()
    {
        _finalHealth = _imaginaryHealth + _player.Damage;

        if (_finalHealth < _player.MaxHealth + 1)
        {
            _player.ChangeHealth(_player.Damage);
            StartCoroutine(DrawHealth());
        }
    }

    private void TakeHealth()
    {
        _finalHealth = _imaginaryHealth - _player.Damage;

        if (_finalHealth > _player.MinHealth - 1)
        {
            _player.ChangeHealth(-_player.Damage);
            StartCoroutine(DrawHealth());
        }
    }
}
