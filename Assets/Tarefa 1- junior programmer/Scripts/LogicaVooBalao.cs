using UnityEngine;
using TMPro;

public class LogicaVooBalao : MonoBehaviour
{
    public Rigidbody rbBalao;
    public float forcaSubida = 35.0f;
    public bool jogoAcabou = false;

    [Header("UI")]
    public TextMeshProUGUI textoGameOver;

    [Header("Efeitos e Sons")]
    public ParticleSystem particulaExplosao;
    public AudioClip somBomba;
    public AudioClip somMoeda; // Novo buraquinho para o som da moeda! ✅
    private AudioSource audioBalao;

    void Start()
    {
        rbBalao = GetComponent<Rigidbody>();
        audioBalao = GetComponent<AudioSource>();
        
        if (textoGameOver != null) textoGameOver.gameObject.SetActive(false);
        jogoAcabou = false;
    }

    void Update()
    {
        if (jogoAcabou) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rbBalao.linearVelocity = Vector3.zero; 
            rbBalao.AddForce(Vector3.up * forcaSubida, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (jogoAcabou) return;

        // SE BATER NA BOMBA 💣
        if (other.CompareTag("Bomb"))
        {
            jogoAcabou = true;
            if (particulaExplosao != null) particulaExplosao.Play();
            if (audioBalao != null && somBomba != null) audioBalao.PlayOneShot(somBomba, 1.0f);
            if (textoGameOver != null) textoGameOver.gameObject.SetActive(true);
            
            Destroy(other.gameObject);
        }

        // SE APANHAR DINHEIRO 💰
        if (other.CompareTag("Money"))
        {
            // O SOM MÁGICO DA MOEDA ✅
            if (audioBalao != null && somMoeda != null) 
                audioBalao.PlayOneShot(somMoeda, 1.0f);
            
            Debug.Log("PLING! Dinheiro no bolso!");
            Destroy(other.gameObject); 
        }
    }
}
