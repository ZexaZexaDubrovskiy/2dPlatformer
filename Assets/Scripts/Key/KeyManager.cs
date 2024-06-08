using TMPro;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _keyTextMeshPro;
    
    public static KeyManager Instance;
    public int needKeys;
    private int _keysPlayer;

    public int KeysPlayer
    {
        get => _keysPlayer;
        set
        {
            _keysPlayer = value;
            UpdateKeysPlayerText();
        }
    }

    private void Start()
    {
        Instance = this;
        needKeys = needKeys == 0 ? 5 : needKeys;
        UpdateKeysPlayerText();
    }

    public void AddKey()
    {
        KeysPlayer++;
    }

    public void RemoveKeys()
    {
        KeysPlayer = 0;
    }

    private void UpdateKeysPlayerText()
    {
        _keyTextMeshPro.text = $"Собрано: {KeysPlayer}/{needKeys} ключей";
    }

    public bool AllKeysCollected() => needKeys == KeysPlayer ? true : false;

}
