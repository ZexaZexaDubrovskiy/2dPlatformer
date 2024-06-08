using UnityEngine;
using UnityEngine.UI;

public class HeartManager : Singleton<HeartManager>
{
    [SerializeField] private Image[] _hearts;
    private int _currentHealth;

    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = Mathf.Clamp(value, 0, _hearts.Length);
            DrawHearts();
        }
    }

    private void Awake()
    {
        CurrentHealth = _hearts.Length;
    }

    private void DrawHearts()
    {
        for (int i = 0; i < _hearts.Length; i++)
            _hearts[i].enabled = i < CurrentHealth;
    }

    public void ResetHearts()
    {
        CurrentHealth = _hearts.Length;
    }

    public void AddHeart()
    {
        if (CurrentHealth < _hearts.Length)
        {
            CurrentHealth++;
        }
    }

    public void RemoveHeart()
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth--;
        }
        else
        {
            PlayerEvents.Instance.Die();
        }
    }

}
