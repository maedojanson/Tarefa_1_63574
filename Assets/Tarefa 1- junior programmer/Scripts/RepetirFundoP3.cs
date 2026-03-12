using UnityEngine;

public class RepetirFundoP3 : MonoBehaviour
{
    private Vector3 posicaoInicial;
    private float larguraRepeticao;

    void Start()
    {
        // Guarda onde o fundo começou
        posicaoInicial = transform.position;
        
        // Vai buscar a largura do collider para saber quando repetir
        larguraRepeticao = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        // Se o fundo andou mais de metade da sua largura para a esquerda...
        if (transform.position.x < posicaoInicial.x - larguraRepeticao)
        {
            // Reseta a posição para o início!
            transform.position = posicaoInicial;
        }
    }
}
