using UnityEngine;

public class ControladorJogador : MonoBehaviour
{
    public GameObject caoPrefab;
    
    // Mudei para 0.15. Assim podes disparar cerca de 6 a 7 cães por segundo!
    // Se quiseres ainda mais rápido, mete 0.1f
    private float intervaloDisparo = 0.15f; 
    private float proximoDisparo = 0;

    void Update()
    {
        // Dispara o cão se carregar no Espaço e o tempo de espera curto já passou
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > proximoDisparo)
        {
            proximoDisparo = Time.time + intervaloDisparo;
            Instantiate(caoPrefab, transform.position, caoPrefab.transform.rotation);
        }
    }
}
