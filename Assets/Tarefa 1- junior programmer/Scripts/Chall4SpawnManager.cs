using UnityEngine;

public class Chall4SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRangeX = 6.0f; // Estreitei um pouco para nascerem mesmo dentro da baliza ✅
    private float spawnZValue = 14.0f; // Aumentei para nascerem mais atrás ✅

    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {
        waveNumber = 1;
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    void Update()
    {
        enemyCount = Object.FindObjectsByType<Chall4Enemy>(FindObjectsSortMode.None).Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        Vector3 powerupPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, 0);
        Instantiate(powerupPrefab, powerupPos, powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        // Agora nascem exatamente no Z da baliza vermelha ✅
        return new Vector3(randomX, 0, spawnZValue);
    }
}
