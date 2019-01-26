using UnityEngine;

public class EnemySeed : MonoBehaviour
{
    private Vector2 _startPos;
    private Vector2 _targetPos;

    public float Speed;
    private float _travelProgress;
    public GameObject[] EnemyPrefabs;

    public void SetPositions(Vector2 startPos, Vector2 targetPos)
    {
        _startPos = startPos;
        _targetPos = targetPos;
    }

    void Update()
    {
        _travelProgress += Time.unscaledDeltaTime;
        transform.position = Vector2.Lerp(_startPos, _targetPos, _travelProgress);
        if (_travelProgress > 1)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)], _targetPos, Quaternion.identity);
        Destroy(gameObject);
    }
}