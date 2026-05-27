using UnityEngine;

public class MoveBasket : MonoBehaviour
{
    public float speed = 3.0f;        // Velocidade do movimento
    public float moveRange = 6.0f;    // Distância máxima para os lados

    private Vector3 startPosition;

    void Start()
    {
        // Garante que o jogo sabe que o centro absoluto é no X = 0
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        startPosition = transform.position;
    }

    void Update()
    {
        // Cria o efeito vai-vém contínuo
        float pingPongX = Mathf.PingPong(Time.time * speed, moveRange * 2) - moveRange;
        
        // Posição alvo calculada
        float targetX = startPosition.x + pingPongX;

        // TRUQUE DE MESTRE: Se o cesto estiver quase a chegar ao zero (meio),
        // nós damos uma ajuda magnética para ele alinhar perfeitamente a 0!
        if (Mathf.Abs(targetX) < 0.4f)
        {
            targetX = 0f;
        }

        // Aplica o movimento suave no eixo X
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
