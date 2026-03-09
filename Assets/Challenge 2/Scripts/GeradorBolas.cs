using UnityEngine;

public class GeradorBolas : MonoBehaviour
{
    public GameObject[] bolasPrefabs;
    private float limiteXEsquerda = -22;
    private float limiteXDireita = 7;
    private float spawnPosY = 30; // Topo do ecrã

    void Start()
    {
        // Começa o ciclo de criação
        Invoke("CriarBolaAleatoria", 1.0f);
    }

    void CriarBolaAleatoria()
    {
        // Escolhe uma bola aleatória (0, 1 ou 2)
        int index = Random.Range(0, bolasPrefabs.Length);

        // Posição X aleatória
        Vector3 spawnPos = new Vector3(Random.Range(limiteXEsquerda, limiteXDireita), spawnPosY, 0);
        
        // Cria a bola
        Instantiate(bolasPrefabs[index], spawnPos, bolasPrefabs[index].transform.rotation);

        // BÓNUS: Define o próximo spawn para um tempo aleatório entre 3 e 5 segundos
        float tempoAleatorio = Random.Range(3.0f, 5.0f);
        Invoke("CriarBolaAleatoria", tempoAleatorio);
    }
}
