using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemySeed EnemyPrefab;

    public Transform StartPos;
    public Transform EndPos;

    public float SpawnTime = 3;
    public Vector2 SpawnTimeRandomRange = new Vector2(0, 1.5f);
    private float _spawnCooldown;

    public int SpawnCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        ResetCooldown();
    }

    private void ResetCooldown()
    {
        _spawnCooldown = SpawnTime + Random.Range(SpawnTimeRandomRange.x, SpawnTimeRandomRange.y);
        SpawnCount--;
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnCount < 0) gameObject.SetActive(false);
        _spawnCooldown -= Time.deltaTime;
        if (_spawnCooldown < 0)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        ResetCooldown();
        var enemy = Instantiate(EnemyPrefab, StartPos.position,
            Quaternion.identity);
        enemy.SetPositions(StartPos.position, EndPos.position);
    }
}