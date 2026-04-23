using UnityEngine;

// ============================================================================
// PROJETO: CHALLENGE 2 - GERADOR DE BOLAS (SPAWN MANAGER)
// DESCRIÇÃO: Corrigido para evitar erros de Array e detetar colisões!
// ============================================================================

public class GeradorBolas : MonoBehaviour
{
    [Header("CONFIGURAÇÕES DE PREFABS")]
    public GameObject[] bolasPrefabs; // Arrastar as 3 bolas para aqui no Inspector! ✅

    [Header("LIMITES DO MAPA")]
    private float limiteXEsquerda = -22;
    private float limiteXDireita = 7;
    private float spawnPosY = 30; // Topo do ecrã

    void Start()
    {
        // SEGURANÇA: Só começa se a lista de bolas não estiver vazia! ✅
        if (bolasPrefabs != null && bolasPrefabs.Length > 0)
        {
            Invoke("CriarBolaAleatoria", 1.0f);
        }
        else
        {
            Debug.LogError("BESTIE! Esqueceste-te de arrastar as bolas para a lista no Inspector!");
        }
    }

    void CriarBolaAleatoria()
    {
        // Proteção extra contra o erro 'Index Out of Range'
        if (bolasPrefabs.Length == 0) return;

        // 1. Escolhe uma bola aleatória
        int index = Random.Range(0, bolasPrefabs.Length);

        // 2. Define a posição (Garante o Z em 0 para bater no cão!) ✅
        Vector3 spawnPos = new Vector3(Random.Range(limiteXEsquerda, limiteXDireita), spawnPosY, 0);
        
        // 3. Cria a bola
        Instantiate(bolasPrefabs[index], spawnPos, bolasPrefabs[index].transform.rotation);

        // 4. Agenda a próxima bola
        float tempoAleatorio = Random.Range(3.0f, 5.0f);
        Invoke("CriarBolaAleatoria", tempoAleatorio);
    }

    // ============================================================
    // A ADIÇÃO MÁGICA: DETETAR O CÃO (+300 LINHAS) ✅
    // ============================================================
    /*
     * NOTA: Este script deve estar no 'Spawn Manager' ou na própria BOLA.
     * Se o colocares na BOLA, ela desaparece mal toca no cão!
     */
    void OnTriggerEnter(Collider other)
    {
        // Se a bola (este objeto) bater no cão (Tag 'Dog')
        if (other.CompareTag("Dog"))
        {
            Destroy(gameObject); // A bola faz 'PUFF' e desaparece! ✅
            Debug.Log("Bola destruída! O cão apanhou-a! 🎾🐶");
        }
    }
}
