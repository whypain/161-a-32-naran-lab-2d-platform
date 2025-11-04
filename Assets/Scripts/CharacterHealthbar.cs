using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthbar : MonoBehaviour
{
    public float Fill => fillImage.fillAmount;

    [SerializeField] private Image fillImage;
    private Character character;


    public void Initialize(Character character, bool persistent)
    {
        this.character = character;
        character.onHealthChanged += OnHealthChanged;
        if (!persistent) character.onDeath += Dispose;
    }

    private void OnHealthChanged(float health01)
    {
        fillImage.fillAmount = health01;
    }

    private void Dispose()
    {
        character.onHealthChanged -= OnHealthChanged;
        character.onDeath -= Dispose;
        Destroy(this.gameObject);
    }
}
