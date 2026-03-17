using UnityEngine;

public class LogicaVooBalao : MonoBehaviour
{
    public Rigidbody rbBalao;
    public AudioSource audioBalao;

    [Header("Configurações de Voo")]
    public float forcaSubida = 25.0f; // Valor mais baixo para ser suave
    public float limiteCeu = 14.5f;
    public float limiteChao = -2.0f; // Morre se cair abaixo disto
    public bool jogoAcabou = false;

    [Header("Efeitos")]
    public ParticleSystem particulaExplosao;
    public AudioClip somBomba;

    void Start()
    {
        if (rbBalao == null) rbBalao = GetComponent<Rigidbody>();
        if (audioBalao == null) audioBalao = GetComponent<AudioSource>();
        
        // Configuração inicial para voo suave
        if (rbBalao != null) rbBalao.linearDamping = 2.5f; 
    }

    void Update()
    {
        if (jogoAcabou) return;

        // 1. CONDIÇÃO DE QUEDA (Fora do ecrã)
        if (transform.position.y < limiteChao)
        {
            GameOver();
        }

        // 2. CONTROLO RATO (Segurar para subir)
        if (Input.GetMouseButton(0) && transform.position.y < limiteCeu)
        {
            rbBalao.AddForce(Vector3.up * forcaSubida, ForceMode.Force);
        }
    }

    private void OnTriggerEnter(Collider outro)
    {
        // 3. CONDIÇÃO DE BOMBA
        if (outro.CompareTag("Bomb") && !jogoAcabou)
        {
            if (particulaExplosao != null) particulaExplosao.Play();
            GameOver();
        }
    }

    void GameOver()
    {
        jogoAcabou = true;
        Debug.Log("GAME OVER! TUDO PAROU.");
        
        if (audioBalao != null && somBomba != null) 
            audioBalao.PlayOneShot(somBomba, 1.0f);

        // Faz o balão cair sem resistência
        rbBalao.linearDamping = 5;
    }
}
