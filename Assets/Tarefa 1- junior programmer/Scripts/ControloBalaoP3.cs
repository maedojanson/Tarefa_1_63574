using UnityEngine;

public class ControloBalaoP3 : MonoBehaviour
{
    private Rigidbody rbBalao;
    public float forcaSubida = 5.0f;
    public float limiteAltura = 15.0f;
    public bool gameOver = false;

    public ParticleSystem particulaExplosao;
    public ParticleSystem particulaFogoArtificio;
    public AudioClip somSalto;
    public AudioClip somExplosao;
    private AudioSource audioBalao;

    void Start()
    {
        rbBalao = GetComponent<Rigidbody>();
        audioBalao = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Sobe se premir Espaço e não estiver muito alto
        if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y < limiteAltura)
        {
            rbBalao.AddForce(Vector3.up * forcaSubida, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            gameOver = true;
            particulaExplosao.Play();
            audioBalao.PlayOneShot(somExplosao, 1.0f);
            Debug.Log("Game Over!");
        }
        else if (other.gameObject.CompareTag("Money"))
        {
            particulaFogoArtificio.Play();
            // Aqui podes adicionar som de moeda se quiseres!
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            // Bónus: Ressalta no chão!
            rbBalao.AddForce(Vector3.up * 7, ForceMode.Impulse);
        }
    }
}
