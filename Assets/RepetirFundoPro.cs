using UnityEngine;

/* * ==========================================================
 * SCRIPT: RepetirFundoP3 (PARA O LOOP INFINITO)
 * ========================================================== */
public class RepetirFundoP3 : MonoBehaviour
{
    private Vector3 posicaoInicial;
    private float largura;

    void Start()
    {
        posicaoInicial = transform.position;
        // Calcula metade da largura do objeto para o salto ser invisível
        if (GetComponent<BoxCollider>() != null)
            largura = GetComponent<BoxCollider>().size.x / 2;
        else
            largura = 50.0f; 
    }

    void Update()
    {
        // Se o cenário andou o suficiente para a esquerda, ele volta ao início 🔄
        if (transform.position.x < posicaoInicial.x - largura)
        {
            transform.position = posicaoInicial;
        }
    }
}
