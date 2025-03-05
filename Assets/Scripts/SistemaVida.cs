using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SistemaVida : MonoBehaviour
{
    public List<RawImage> listaCorazones;
    public PlayerController jugador;
    public Sprite corazonLleno;
    public Sprite corazonVacio;
    public int vidaMaxima = 3;
    public int vidaActual = 3;
    public GameObject pantallaMuerte;
    public float tiempoEsperaMuerte = 3f;
    public AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        jugador.cambioVida.AddListener(ActualizarVida);
        ActualizarVida(jugador.vidaActual);
    }

    public void ActualizarVida(int vidaJugador)
    {
        vidaActual = vidaJugador;

        // Pintamos corazones vacíos desde el último hacia atrás
        for (int i = vidaMaxima - 1; i >= vidaActual; i--)
        {
            listaCorazones[i].texture = corazonVacio.texture;
        }

        // Pintamos corazones llenos desde el principio hasta la vida actual
        for (int i = 0; i < vidaActual; i++)
        {
            listaCorazones[i].texture = corazonLleno.texture;
        }

        if (vidaActual == 0)
        {
            Morir();
        }
    }

    public void Morir()
    {
        pantallaMuerte.SetActive(true);
        audioManager.PlaySFX(audioManager.deathSound);
        StartCoroutine(ReiniciarNivel());
    }

    IEnumerator ReiniciarNivel()
    {
        yield return new WaitForSeconds(tiempoEsperaMuerte);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
