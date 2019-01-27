using Anima2D;
using UnityEngine;

[ExecuteInEditMode]
public class SortingLayer : MonoBehaviour
{
    public int offset;

    private SpriteMeshInstance _spriteMeshInstance;
    private SpriteRenderer _renderer;

    void Awake()
    {
        _spriteMeshInstance = GetComponent<SpriteMeshInstance>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Update()
    {
        if (_spriteMeshInstance)
            _spriteMeshInstance.sortingOrder = -(int)(transform.position.y * 1000) + offset;
        if(_renderer)
            _renderer.sortingOrder = -(int)(transform.position.y * 1000) + offset;
    }

}
