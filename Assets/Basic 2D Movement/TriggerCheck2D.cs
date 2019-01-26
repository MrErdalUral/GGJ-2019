using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class TriggerCheck2D : MonoBehaviour
{
    public UnityEvent OnTriggerEnter;
    public UnityEvent OnTriggerExit;

    public bool Value { get { return _listOfCollisions.Count > 0; } }
    [SerializeField]
    private List<GameObject> _listOfCollisions;
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;
    void Awake()
    {
        _listOfCollisions = new List<GameObject>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_rigidbody2D == null)
        {
            _rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
            _rigidbody2D.isKinematic = true;
        }
        _collider2D = GetComponent<Collider2D>();
        _collider2D.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _listOfCollisions.Add(collision.gameObject);
        OnTriggerEnter.Invoke();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _listOfCollisions.Remove(collision.gameObject);
        OnTriggerExit.Invoke();
    }
}