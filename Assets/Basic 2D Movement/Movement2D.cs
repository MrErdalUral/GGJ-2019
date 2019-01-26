using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{
    public float MaxSpeed = 10;
    public float Acceleration = 5;
    public bool IsTimeUnscaled = false;

    private Vector2 _direction;
    private Rigidbody2D _rigidbody2D;

    public Vector2 Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void SetDirection(Vector2 dir)
    {
        Direction = dir;
    }
    void FixedUpdate()
    {
        var targetVelocity = Direction * MaxSpeed;
        var deltaTime = (IsTimeUnscaled ? Time.unscaledDeltaTime : Time.deltaTime);
        var timedBasedAcceleration = deltaTime * Acceleration;
        if (timedBasedAcceleration > 1) timedBasedAcceleration = 1;
        var velocity = timedBasedAcceleration * targetVelocity + (1 - timedBasedAcceleration) * _rigidbody2D.velocity;
        if (!IsTimeUnscaled)
            velocity /= Time.deltaTime;
        _rigidbody2D.velocity = velocity;
    }

    public Vector2 GetMovingDirection()
    {
        return Direction;
    }
}