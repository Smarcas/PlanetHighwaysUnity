using UnityEngine;

public class CoinsScript : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float cantPuntos = 100f;
    [SerializeField] public Puntuacion puntuacion;
    [SerializeField] private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        // Hacemos que el planeta rote todo el rato sobre si mismo
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.coinSound);
            puntuacion.SumarPuntos(cantPuntos);
            Destroy(gameObject);
        }
    }
}
