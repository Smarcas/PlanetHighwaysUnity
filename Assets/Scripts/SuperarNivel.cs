using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SuperarNivel : MonoBehaviour
{
    public PlayerController jugador;
    public AudioManager audioManager;
    public GameObject pantallaVictoria;
    [SerializeField] public PantallaPuntuacion pantallaPuntuacion;
    [SerializeField] public Puntuacion puntuacion;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.victorySound);
            StartCoroutine(PantallaVictoria());
        }
    }

    IEnumerator PantallaVictoria()
    {
        pantallaPuntuacion.puntuacionFinal = puntuacion.puntos;
        pantallaVictoria.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
