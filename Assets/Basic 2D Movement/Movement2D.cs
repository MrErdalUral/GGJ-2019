using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{
    public float MaxSpeed = 10;
    public float Acceleration = 5;
    public bool IsTimeUnscaled = false;
    public Animator Animator;

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
        if(dir == Vector2.zero) return;
        transform.localScale = new Vector3(Mathf.Sign(dir.x), 1, 1);
    }
    void FixedUpdate()
    {
        var targetVelocity = Direction * MaxSpeed;
        var value = targetVelocity.sqrMagnitude > 0;
        if (Animator)
        {
            Animator.SetBool("Walking", value);
           
        }

        var timedBasedAcceleration = (IsTimeUnscaled ? Time.unscaledDeltaTime : Time.deltaTime) * Acceleration;
        if (timedBasedAcceleration > 1) timedBasedAcceleration = 1;
        var velocity = timedBasedAcceleration * targetVelocity + (1 - timedBasedAcceleration) * _rigidbody2D.velocity;
        _rigidbody2D.velocity = velocity / Time.timeScale;
        if (value)
        {
            Animator.speed = 1 + timedBasedAcceleration*2;
        }
        else
        {
            Animator.speed = 1;
        }
    }

    public Vector2 GetMovingDirection()
    {
        return Direction;
    }
}