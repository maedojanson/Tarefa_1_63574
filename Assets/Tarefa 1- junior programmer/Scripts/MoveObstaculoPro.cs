using UnityEngine;

public class MoveObstaculoPro : MonoBehaviour
{
    public float velocidade = 15.0f;
    private ControladorPersonagemP3 scriptPlayer;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null) scriptPlayer = player.GetComponent<ControladorPersonagemP3>();
    }

    void Update()
    {
        if (scriptPlayer != null && !scriptPlayer.gameOver)
        {
            transform.Translate(Vector3.left * velocidade * Time.deltaTime, Space.World);
        }

        if (transform.position.x < -15) { Destroy(gameObject); }
    }
}
