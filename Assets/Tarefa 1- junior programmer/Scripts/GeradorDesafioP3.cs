using UnityEngine;

public class GeradorDesafioP3 : MonoBehaviour
{
    public GameObject[] prefabsObjetos; // Moedas e Bombas
    private float tempoEspera = 2.5f;
    private float intervalo = 1.5f;
    private ControloBalaoP3 scriptBalao;

    void Start()
    {
        scriptBalao = GameObject.Find("Player").GetComponent<ControloBalaoP3>();
        InvokeRepeating("GerarObjeto", tempoEspera, intervalo);
    }

    void GerarObjeto()
    {
        if (!scriptBalao.gameOver)
        {
            int index = Random.Range(0, prefabsObjetos.Length);
            Vector3 spawnPos = new Vector3(30, Random.Range(3, 12), 0);
            Instantiate(prefabsObjetos[index], spawnPos, prefabsObjetos[index].transform.rotation);
        }
    }
}
