using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class HealthRendering : MonoBehaviour
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

    public void UpdateUIElements()
    {
        _sliderHealth.value = _imaginaryHealth;
        _healthText.text = $"Î×ÊÈ ÆÈÇÍÈ: {((int)_imaginaryHealth)}";
    }

    public IEnumerator DrawHealth(int damage)
    {
        _finalHealth = _imaginaryHealth + damage;

        while (_imaginaryHealth != _finalHealth)
        {
            _imaginaryHealth = Mathf.MoveTowards(_imaginaryHealth, _finalHealth , _maxDelta * Time.deltaTime);
            UpdateUIElements();

            yield return null;
        }
    }
}
