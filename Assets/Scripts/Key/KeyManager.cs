using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyManager : Singleton<KeyManager>
{

    [SerializeField] private TextMeshProUGUI _keyTextMeshPro;
    private int _keysPlayer;

    public int KeysPlayer
    {
        get { return _keysPlayer; }
        set { _keysPlayer = value; }
    }

    public void AddKey()
    {
        ++KeysPlayer;
        UpdateKeysPlayerText(KeysPlayer);
    }

    private void UpdateKeysPlayerText(int KeysPlayer)
    {
        _keyTextMeshPro.text = $"Собрано: {KeysPlayer}/5 ключей";
    }

}
