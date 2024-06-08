using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public static PlayerEvents Instance;
    private PlayerAnimations _anim;
    private bool _isHiting;

    private void Awake()
    {
        Instance = this;
        _anim = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        _anim.IsHiting = _isHiting;
        _isHiting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Heart")
        {
            HeartManager.Instance.AddHeart();
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "Key")
        {
            KeyManager.Instance.AddKey();
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "Obstacle")
        {
            HeartManager.Instance.RemoveHeart();
            _isHiting = true;
        }
    }


    public void Die() => GameManager.Instance.Restart();


}
