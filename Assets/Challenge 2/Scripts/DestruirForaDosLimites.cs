using UnityEngine;

public class DestruirForaDosLimites : MonoBehaviour
{
    private float limiteEsquerda = -50.0f; 
    private float limiteAbaixo = -5.0f;   

    void Update()
    {
        // Se for o CÃO (Eixo X)
        if (transform.position.x < limiteEsquerda)
        {
            Destroy(gameObject);
        } 
        
        // Se for a BOLA (Eixo Y) - Só apaga se cair mesmo abaixo do chão
        if (transform.position.y < limiteAbaixo)
        {
            Destroy(gameObject);
        }
    }
}
