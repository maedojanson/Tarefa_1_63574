using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        // Define a posição inicial do cubo
        transform.position = new Vector3(3, 4, 1);
        
        // Define um tamanho gigante para começar
        transform.localScale = Vector3.one * 5;
    }
    
    void Update()
    {
        // 1. Faz o cubo rodar em vários eixos ao mesmo tempo
        transform.Rotate(20.0f * Time.deltaTime, 50.0f * Time.deltaTime, 30.0f * Time.deltaTime);

        // 2. Faz o cubo "pulsar" (mudar de escala sozinho)
        float escala = 2.0f + Mathf.PingPong(Time.time, 3.0f);
        transform.localScale = Vector3.one * escala;

        // 3. MUDANÇA DE COR DINÂMICA (Bónus Criativo)
        // Cria uma cor que muda baseada no tempo
        Color novaCor = new Color(Mathf.Sin(Time.time), Mathf.Cos(Time.time), 0.5f, 0.7f);
        
        Material material = Renderer.material;
        material.color = novaCor;
    }
}
