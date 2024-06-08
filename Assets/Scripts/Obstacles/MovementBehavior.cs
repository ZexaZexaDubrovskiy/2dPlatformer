using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField] private float checkDistance;
    [SerializeField] private SpriteRenderer _obstacleSprite;

    private Vector3 _direction;
    public float _speed = 5f;

    private void Awake()
    {
        _direction = Vector2.right;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + _direction, _direction, checkDistance);
        if (hit.collider != null && hit.collider.CompareTag("Ground"))
        {
            _direction = -_direction;
            _obstacleSprite.flipX = _direction == Vector3.right ? true : false;
        }

        transform.Translate(_direction * _speed * Time.deltaTime);
    }

}
