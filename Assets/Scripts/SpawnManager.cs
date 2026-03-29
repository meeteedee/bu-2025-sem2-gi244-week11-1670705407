using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave 
{
    public int totalSpawnEnemies;
    public int numberOfRandomSpawnPoint;
    public float delayStart;
    public float spawnInterval;
    public int numberOfPowerUp;
}

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    public Wave[] waves;

    void Start()
    {
        StartCoroutine(SpawnWaveRoutine());
    }

    IEnumerator SpawnWaveRoutine()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            Wave currentWave = waves[i];

            for (int p = 0; p < currentWave.numberOfPowerUp; p++)
            {
                SpawnRandomPowerUp();
            }

            List<Transform> selectedSpawnPoints = GetRandomSpawnPoints(currentWave.numberOfRandomSpawnPoint);

            yield return new WaitForSeconds(currentWave.delayStart);

            for (int e = 0; e < currentWave.totalSpawnEnemies; e++)
            {
                int randomIndex = Random.Range(0, selectedSpawnPoints.Count);
                Transform sp = selectedSpawnPoints[randomIndex];
                
                Instantiate(enemyPrefab, sp.position, sp.rotation);

                yield return new WaitForSeconds(currentWave.spawnInterval);
            }

            yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Enemy").Length == 0);
            
            yield return new WaitForSeconds(2f); 
        }
    }
    
    List<Transform> GetRandomSpawnPoints(int count)
    {
        List<Transform> availablePoints = new List<Transform>(spawnPoints);
        List<Transform> selected = new List<Transform>();

        for (int i = 0; i < count; i++)
        {
            if (availablePoints.Count > 0)
            {
                int randomIndex = Random.Range(0, availablePoints.Count);
                selected.Add(availablePoints[randomIndex]);
                availablePoints.RemoveAt(randomIndex);
            }
        }
        return selected;
    }
    
    void SpawnRandomPowerUp()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomZ = Random.Range(-10f, 10f);
        
        Vector3 randomPos = new Vector3(randomX, 0.5f, randomZ); 
        
        Instantiate(powerUpPrefab, randomPos, Quaternion.identity);
    }
}