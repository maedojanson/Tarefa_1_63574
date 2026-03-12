using UnityEngine;

public class ControladorPersonagemP3 : MonoBehaviour
{
    // --- Componentes ---
    private Rigidbody rbJogador;
    private Animator playerAnim;
    private AudioSource somJogador;

    // --- Variáveis de Configuração ---
    [Header("Física e Movimento")]
    public float forcaSalto = 10.0f;
    public float modificadorGravidade = 2.0f;
    public bool estaNoChao = true;
    public bool gameOver = false;

    [Header("Efeitos Visuais")]
    public ParticleSystem particulaExplosao;
    public ParticleSystem particulaPoeira;

    [Header("Efeitos Sonoros")]
    public AudioClip somSalto;
    public AudioClip somBatida;

    void Start()
    {
        // Inicialização de componentes
        rbJogador = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        somJogador = GetComponent<AudioSource>();

        // Ajuste da gravidade para o salto não parecer "lunar"
        Physics.gravity = new Vector3(0, -9.81f, 0) * modificadorGravidade;

        // Garante que a poeira começa a tocar se o jogo inicia no chão
        if (particulaPoeira != null) { particulaPoeira.Play(); }
    }

    void Update()
    {
        // Comando de Salto: Espaço + No Chão + Jogo Ativo
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao && !gameOver)
        {
            rbJogador.AddForce(Vector3.up * forcaSalto, ForceMode.Impulse);
            estaNoChao = false;

            // Ativa animação e som de salto
            playerAnim.SetTrigger("Jump_trig");
            somJogador.PlayOneShot(somSalto, 1.0f);

            // Para a poeira enquanto está no ar
            if (particulaPoeira != null) { particulaPoeira.Stop(); }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Deteta colisão com o Chão
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            estaNoChao = true;
            // Reinicia a poeira ao aterrar
            if (particulaPoeira != null) { particulaPoeira.Play(); }
        }
        // Deteta colisão com Obstáculos
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over: Colisão detectada.");

            // Ativa animações de queda
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            // Efeitos de explosão e som de impacto
            if (particulaExplosao != null) { particulaExplosao.Play(); }
            if (particulaPoeira != null) { particulaPoeira.Stop(); }
            
            somJogador.PlayOneShot(somBatida, 1.0f);
        }
    }
}
