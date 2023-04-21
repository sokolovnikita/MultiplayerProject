using UnityEngine;
using UnityEngine.UI;

public class ActualCoinBar : MonoBehaviour
{
    [SerializeField] private CharacterBase _character;

    private Image _coinBarImage;

    private void Awake()
    {
        _coinBarImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _character.OnTookCoinEvent += UpdateCoinBar;
    }

    private void OnDisable()
    {
        _character.OnTookCoinEvent -= UpdateCoinBar;
    }

    private void UpdateCoinBar(int maxCoins, int actualCoins)
    {
        _coinBarImage.fillAmount = (float)actualCoins / (float)maxCoins;
    }
}
