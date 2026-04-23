using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed = 15.0f;
    private LogicaVooBalao scriptBalao;

    void Start()
    {
        // Encontra o balão para saber se o jogo acabou
        GameObject player = GameObject.Find("Player");
        if (player != null) scriptBalao = player.GetComponent<LogicaVooBalao>();
    }

    void Update()
    {
        // Só anda se o balão ainda estiver vivo! ✅
        if (scriptBalao != null && !scriptBalao.jogoAcabou)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // Se fugir do ecrã, apaga para não pesar ✅
        if (transform.position.x < -15) Destroy(gameObject);
    }
}
