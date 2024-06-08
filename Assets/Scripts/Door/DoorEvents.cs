using UnityEngine;

public class DoorEvents : MonoBehaviour
{
    private DoorAnimations _anim;
    private bool _isOpen;

    private void Awake()
    {  
        _anim = GetComponent<DoorAnimations>();
    }

    private void Update()
    {
        _anim.IsOpen = _isOpen;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") && KeyManager.Instance.AllKeysCollected())
        {
            _isOpen = true;
            GameManager.Instance.Restart();
        }
    }

}
