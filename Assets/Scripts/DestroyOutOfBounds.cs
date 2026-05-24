using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topLimit = 35.0f;    // Onde a pizza desaparece lá na frente
    private float lowerLimit = -15.0f;  // Onde o cão desaparece se passar por ti

    void Update()
    {
        // 1. Se a pizza passar do topo do ecrã
        if (transform.position.z > topLimit)
        {
            // Em vez de Destroy, mandamos de volta para a pool invisível!
            gameObject.SetActive(false); 
        }
        // 2. Se um cão passar de ti e fugir pelo fundo do ecrã
        else if (transform.position.z < lowerLimit)
        {
            // O cão também volta para a pool
            gameObject.SetActive(false);
            
            Debug.Log("Um animal conseguiu fugir da quinta!");
        }
    }
}
