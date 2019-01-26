using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public Vector2 EndPos;
    public Transform PivotPos;
    private Rigidbody2D _body;
    private Rigidbody2D _pivotBody;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _pivotBody = PivotPos.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _body.velocity = Vector2.Perpendicular((Vector2)transform.position - (Vector2)PivotPos.position)*10 + _pivotBody.velocity;
    }
}