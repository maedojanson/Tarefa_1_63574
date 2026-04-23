using UnityEngine;

public class Lab4SpawnManager : MonoBehaviour
{
    public GameObject bolaPrefab;   // Amarela (Projétil solto)
    public GameObject cuboPrefab;   // Vermelho (Obstáculo estático)
    public GameObject escudoPrefab; // Cinzento (Powerup)

    private float range = 12.0f;

    void Start() {
        // Cubos Vermelhos: mudei para 4.0f (aparece um a cada 4 segundos) ✅
        InvokeRepeating("SpawnCubo", 2.0f, 4.0f); 
        
        // Bolas Amarelas: a cada 5 segundos ✅
        InvokeRepeating("SpawnBola", 1.0f, 5.0f);
        
        // Escudos Cinzentos: a cada 15 segundos (Raro!) ✅
        InvokeRepeating("SpawnEscudo", 10.0f, 15.0f);
    }

    void SpawnBola() { 
        if(bolaPrefab != null) Instantiate(bolaPrefab, RandomPos(), Quaternion.identity); 
    }
    
    void SpawnCubo() { 
        if(cuboPrefab != null) Instantiate(cuboPrefab, RandomPos(), Quaternion.identity); 
    }
    
    void SpawnEscudo() { 
        if(escudoPrefab != null) Instantiate(escudoPrefab, RandomPos(), Quaternion.identity); 
    }

    Vector3 RandomPos() {
        return new Vector3(Random.Range(-range, range), 0.7f, Random.Range(-range, range));
    }
}
