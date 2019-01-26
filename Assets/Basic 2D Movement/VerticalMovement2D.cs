using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VerticalMovement2D : MonoBehaviour
{

    public float MaxSpeed = 10;
    public float Acceleration = 5;

    private int _direction;
    private Rigidbody2D _rigidbody2D;

    public int Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void SetDirection(float dir)
    {
        Direction = Mathf.RoundToInt(dir);
    }
    void FixedUpdate()
    {
        var targetVelocity = Direction * MaxSpeed;
        var timedBasedAcceleration = Time.deltaTime * Acceleration;
        if (timedBasedAcceleration > 1) timedBasedAcceleration = 1;
        var velocity = timedBasedAcceleration * targetVelocity + (1 - timedBasedAcceleration) * _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, velocity);
    }

}