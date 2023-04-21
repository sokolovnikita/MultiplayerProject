using UnityEngine;
using UnityEngine.UI;

public class ActualHealthBar : MonoBehaviour
{
    [SerializeField] private CharacterBase _character;

    private Image _healthBarImage;

    private void Awake()
    {
        _healthBarImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _character.OnTookDamageEvent += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _character.OnTookDamageEvent -= UpdateHealthBar;
    }

    private void UpdateHealthBar(int maxHealthPoints, int actualHealthPoints)
    {
        Debug.Log($"actual - {actualHealthPoints} max - {maxHealthPoints}");
        _healthBarImage.fillAmount = (float)actualHealthPoints / (float)maxHealthPoints;
    }
}
