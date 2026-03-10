using UnityEngine;

public class ControladorDoJogador : MonoBehaviour
{
    public float velocidade = 10.0f;
    public GameObject projetilPrefab;

    void Update()
    {
        // Movimento para frente/trás e lados
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * vertical * Time.deltaTime * velocidade);
        transform.Translate(Vector3.right * horizontal * Time.deltaTime * velocidade);

        // Disparar com Espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projetilPrefab, transform.position, transform.rotation);
        }
    }
}
