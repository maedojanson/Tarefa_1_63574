using UnityEngine;

/* * ==========================================================
 * SCRIPT: MoverCenarioCaixaEsquerda (VERSÃO ANTI-SOLUÇO)
 * DESCRIÇÃO: Movimento suave e sincronizado.
 * ========================================================== */
public class MoverCenarioCaixaEsquerda : MonoBehaviour
{
    public float velocidade = 15.0f;
    private ControladorPersonagemP3 scriptPlayer;

    void Start()
    {
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj != null) 
            scriptPlayer = playerObj.GetComponent<ControladorPersonagemP3>();
    }

    // Usamos LateUpdate para evitar que o chão trema (soluços) ✅
    void LateUpdate()
    {
        if (scriptPlayer != null && !scriptPlayer.gameOver)
        {
            transform.Translate(Vector3.left * velocidade * Time.deltaTime, Space.World);
        }
    }

    // Destrói apenas se for obstáculo
    void Update()
    {
        if (gameObject.CompareTag("Obstacle") && transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}