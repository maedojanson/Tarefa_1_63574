using UnityEngine;

public class Lab5SpawnManager : MonoBehaviour
{
    public GameObject bolaPrefab;    // Maçã Coletável (Tag: Municao)
    public GameObject cuboPrefab;    // Caixa com ? (Tag: Enemy)
    public GameObject cavaloPrefab;  // O Prefab do Cavalo (Com Lab5Shooter)

    private GameObject cavaloAtual;  
    private float range = 12.0f;

    void Start() {
        // MODIFICADO: Agora nasce uma maçã a cada 1.5 segundos em vez de 4! 🍎✨
        InvokeRepeating("SpawnBola", 0.5f, 1.5f);   
        InvokeRepeating("SpawnCubo", 2.0f, 5.0f);   
        InvokeRepeating("SpawnCavalo", 3.0f, 4.0f); 
    }

    void SpawnBola() { 
        if(bolaPrefab != null) Instantiate(bolaPrefab, RandomPos(), Quaternion.identity); 
    }
    
    void SpawnCubo() { 
        if(cuboPrefab != null) Instantiate(cuboPrefab, RandomPos(), Quaternion.identity); 
    }

    void SpawnCavalo() { 
        if (cavaloPrefab != null && cavaloAtual == null) {
            cavaloAtual = Instantiate(cavaloPrefab, RandomPos(), Quaternion.identity); 
            Debug.Log("🐎 Um único cavalo nasceu na arena!");
        }
    }

    Vector3 RandomPos() {
        return new Vector3(Random.Range(-range, range), 0.5f, Random.Range(-range, range));
    }
}
