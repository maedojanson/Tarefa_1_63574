using UnityEngine;

public class Proto4SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;    // Arrastar o Enemy azul aqui ✅
    public GameObject powerupPrefab;  // Arrastar o Powerup azul aqui ✅
    private float spawnRange = 9.0f;

    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    void Update()
    {
        // Conta inimigos (Versão Unity 6)
        enemyCount = Object.FindObjectsByType<Proto4Enemy>(FindObjectsSortMode.None).Length;

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
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}
