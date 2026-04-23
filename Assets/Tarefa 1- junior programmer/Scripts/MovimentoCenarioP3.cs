/*using UnityEngine;

public class GeradorObstaculosP3 : MonoBehaviour
{
    public GameObject[] prefabs;
    private LogicaVooBalao scriptBalao; // Ligação ao script do balão
    private float tempoEspera = 2.0f;
    private float intervalo = 2.0f;

    void Start()
    {
        // Procura o balão pelo nome "Player" na Hierarchy
        GameObject playerObj = GameObject.Find("Player");
        
        if (playerObj != null) 
        {
            scriptBalao = playerObj.GetComponent<LogicaVooBalao>();
        }

        // Começa a gerar obstáculos
        InvokeRepeating("Spawn", tempoEspera, intervalo);
    }

    void Spawn()
    {
        // SÓ GERA se o balão existir e o jogo NÃO tiver acabado
        if (scriptBalao != null && !scriptBalao.jogoAcabou)
        {
            int index = Random.Range(0, prefabs.Length);
            // Ajusta o X para 25 (fora da tela) e o Z para 0
            Vector3 spawnPos = new Vector3(25, Random.Range(3, 11), 0);
            
            Instantiate(prefabs[index], spawnPos, prefabs[index].transform.rotation);
        }
    }
}*/
