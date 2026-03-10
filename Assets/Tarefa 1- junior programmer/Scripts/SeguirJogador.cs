using UnityEngine;

public class SeguirJogador : MonoBehaviour
{
    public Transform alvo; // Aqui arrastas o teu Player no Unity
    public float velocidadeInimigo = 3.0f;

    void Update()
    {
        if (alvo != null)
        {
            // Olha para o jogador e caminha na direção dele
            Vector3 direcao = (alvo.position - transform.position).normalized;
            transform.Translate(direcao * velocidadeInimigo * Time.deltaTime);
        }
    }
}
