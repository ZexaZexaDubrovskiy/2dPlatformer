using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : Singleton<PlayerEvents>
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Heart")
        {
            HeartManager.Instance.ChangeValueHeart(1);
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "Key")
        {
            KeyManager.Instance.AddKey();
            Destroy(collision.gameObject);
        }


    }

}
