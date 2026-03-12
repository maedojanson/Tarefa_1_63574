using UnityEngine;

public class GeradorObstaculosP3 : MonoBehaviour
{
    public GameObject obstaculoPrefab; // Arrasta o teu prefab para aqui no Inspector
    private Vector3 posicaoSpawn = new Vector3(25, 0, 0); // Ajusta o 25 se o obstáculo aparecer muito perto
    private float atrasoInicial = 2;
    private float intervaloRepeticao = 2;

    void Start()
    {
        // Chama a função de criar obstáculo repetidamente
        InvokeRepeating("CriarNovoObstaculo", atrasoInicial, intervaloRepeticao);
    }

    void CriarNovoObstaculo()
    {
        Instantiate(obstaculoPrefab, posicaoSpawn, obstaculoPrefab.transform.rotation);
    }
   
}
