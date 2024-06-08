using UnityEngine;

public class ElevatorBehavior : MonoBehaviour
{
    public float maxHeight;
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private float startHeight;
    private bool movingUp;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        startHeight = transform.position.y;
        movingUp = true;
    }

    private void FixedUpdate() => Move();

    private void Move()
    {
        if (movingUp)
        {
            if (transform.position.y < startHeight + maxHeight)
                _rb.MovePosition(_rb.position + Vector2.up * _speed * Time.fixedDeltaTime);
            else
                movingUp = false;
        }
        else
        {
            if (transform.position.y > startHeight)
                _rb.MovePosition(_rb.position + Vector2.down * _speed * Time.fixedDeltaTime);
            else
                movingUp = true;
        }
    }

}
