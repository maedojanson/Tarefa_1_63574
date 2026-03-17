using UnityEngine;

// O nome aqui TEM de ser igual ao nome do ficheiro lá fora!
public class GeradorObstaculosP3 : MonoBehaviour
{
    public GameObject[] prefabs;
    private LogicaVooBalao scriptBalao;

    void Start()
    {
        // Tenta encontrar o objeto Player
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj != null) {
            scriptBalao = playerObj.GetComponent<LogicaVooBalao>();
        } else {
            Debug.LogError("Bestie, não encontro o objeto chamado 'Player' na Hierarchy!");
        }

        InvokeRepeating("Spawn", 2.0f, 2.0f);
    }

    void Spawn()
    {
        // Só gera se encontrou o script e o jogo não acabou
        if (scriptBalao != null && !scriptBalao.jogoAcabou)
        {
            int index = Random.Range(0, prefabs.Length);
            // Z tem de ser 0 para aparecer na frente da camera!
            Vector3 spawnPos = new Vector3(25, Random.Range(3, 11), 0);
            Instantiate(prefabs[index], spawnPos, prefabs[index].transform.rotation);
        }
    }
}