using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _asteroidPrefab;
    [SerializeField] private GameObject[] powerups;
    [SerializeField] private float _waitForSeconds = 5.0f;
    private bool _stopSpawning = false;

    void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnRoutineAsteroid());
        StartCoroutine(SpawnRoutineEnemy());
        StartCoroutine(SpawnRoutinePowerUp());
    }

    IEnumerator SpawnRoutineAsteroid()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9.0f, 9.0f), 8, 0);
            GameObject newAsteroid = Instantiate(_asteroidPrefab, posToSpawn, Quaternion.identity);
            newAsteroid.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_waitForSeconds);
        }
    }

    IEnumerator SpawnRoutineEnemy()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9.0f, 9.0f), 10, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(2,5));
        }
    }

    IEnumerator SpawnRoutinePowerUp()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9.0f, 9.0f), 9, 0);
            int randomPowerUp = Random.Range(0, powerups.Length);
            Instantiate(powerups[randomPowerUp], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(7,21));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
