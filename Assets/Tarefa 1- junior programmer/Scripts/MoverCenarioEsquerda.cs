using UnityEngine;

public class MoverCenarioEsquerda : MonoBehaviour
{
    private float velocidade = 30;
    private ControladorPersonagemP3 scriptControle;

    void Start()
    {
        // Procura o boneco na cena e guarda o script dele
        scriptControle = GameObject.Find("SimplePeople").GetComponent<ControladorPersonagemP3>();
    }

    void Update()
    {
        // SÓ move se o gameOver for falso
        if (scriptControle != null && scriptControle.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * velocidade);
        }
        if (transform.position.x < -15 && gameObject.CompareTag("Obstacle")) {
    Destroy(gameObject);
}
    }
}
