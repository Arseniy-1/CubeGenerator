using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Vector3> _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Target _target;
    private int _delay = 2;

    private void Start()
    {
        StartCoroutine(SpawningEnemy());
    }

    private IEnumerator SpawningEnemy()
    {
        var delay = new WaitForSeconds(_delay);

        while (true)
        {
            SpawnEnemy();
            yield return delay;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 randomPosition = _spawnPoints[Random.Range(0, _spawnPoints.Count)];

        Enemy enemy = Instantiate(_enemyPrefab);
        enemy.Initialize(_target);
        enemy.transform.position = randomPosition;
    }
}
