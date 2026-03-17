using UnityEngine;

public class CicloInfinitoCenario : MonoBehaviour
{
    public float velocidadeCenario = 10f;
    private Vector3 posicaoRecomeco;
    private float larguraDoFundo;
    private ControloBalaoP3 scriptLogica;

    void Start()
    {
        posicaoRecomeco = transform.position;
        // Calcula a largura exata para o loop ser perfeito
        larguraDoFundo = GetComponent<BoxCollider>().size.x / 2;
        
        // Procura o script do balão para saber quando parar
        scriptLogica = GameObject.Find("Player").GetComponent<ControloBalaoP3>();
    }

    void Update()
    {
        // Se o jogo não acabou, move o fundo
        if (scriptLogica != null && !scriptLogica.gameOver)
        {
            transform.Translate(Vector3.left * velocidadeCenario * Time.deltaTime);
        }

        // Se o fundo passar do limite, volta à posição inicial
        if (transform.position.x < posicaoRecomeco.x - larguraDoFundo)
        {
            transform.position = posicaoRecomeco;
        }
    }
}
