using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump2D : MonoBehaviour
{
    public Vector2 JumpVector = new Vector2(0, 20);
    public UnityEvent OnJump;

    private Rigidbody2D _rigidbody2D;
    private GroundCheckStatus2D _status;

    [SerializeField]
    private bool _input;

    [SerializeField]
    private bool _jumpStarted;
    void Awake()
    {
        _input = false;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _status = GetComponent<GroundCheckStatus2D>();
    }

    public void JumpInput(bool input)
    {
        _input = input;
    }

    void Update()
    {
        if (_status.CanJump)
            _jumpStarted = false;
        else
            _rigidbody2D.gravityScale = _input && _rigidbody2D.velocity.y > 0 ? 1 : 2;
    }

    void FixedUpdate()
    {
        if (_input && _status.CanJump && !_jumpStarted)
        {
            _jumpStarted = true;
            var v = _rigidbody2D.velocity;
            v.y = JumpVector.y;
            _rigidbody2D.velocity = v;
            if (OnJump != null)
                OnJump.Invoke();
        }
    }
    public void Log()
    {
        Debug.Log("Jump!");
    }
}