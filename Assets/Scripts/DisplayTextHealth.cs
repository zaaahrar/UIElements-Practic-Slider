using TMPro;
using UnityEngine;

public class DisplayTextHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text _textHealth;

    public void UpdateText(float newHealth, float maxHealth)
    {
        _textHealth.text = $"{(int)newHealth}/{maxHealth}";
    }
}
