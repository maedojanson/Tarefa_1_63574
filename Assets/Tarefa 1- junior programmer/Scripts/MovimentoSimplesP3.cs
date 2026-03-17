using UnityEngine;

public class MovimentoSimplesP3 : MonoBehaviour
{
    public float velocidade = 10f;
    private ControloBalaoP3 scriptBalao;

    void Start()
    {
        // Tenta encontrar o balão para saber se o jogo acabou
        GameObject jogador = GameObject.Find("Player");
        if (jogador != null) {
            scriptBalao = jogador.GetComponent<ControloBalaoP3>();
        }
    }

    void Update()
    {
        // Se o jogo não acabou (ou se o balão não existir), move-se
        if (scriptBalao == null || !scriptBalao.gameOver)
        {
            transform.Translate(Vector3.left * velocidade * Time.deltaTime);
        }

        // Se sair do ecrã e não for o fundo, destrói-se
        if (transform.position.x < -15 && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }
}
