using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    void Start()
    {
        // Começa a criar animais automaticamente
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        // Escolhe animal aleatório
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        
        // Posição X aleatória
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        // Cria o animal
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
    
    // O Update fica vazio porque o InvokeRepeating trata de tudo
    void Update()
    {
    }
}