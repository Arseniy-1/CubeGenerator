using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Vector3> _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;
    private int _delay = 2;

    private List<Vector3> _directions = new List<Vector3>
    {
        Vector3.right,
        -Vector3.right,
        Vector3.left,
        -Vector3.left,
        Vector3.forward,
        -Vector3.forward,
    };

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
        Vector3 randomDirestion = _directions[Random.Range(0, _directions.Count)];

        Enemy enemy = Instantiate(_enemyPrefab);
        enemy.Initialize(randomDirestion);
        enemy.transform.position = randomPosition;
    }
}
