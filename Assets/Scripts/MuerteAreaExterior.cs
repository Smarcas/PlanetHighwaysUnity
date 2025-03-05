using System;
using UnityEngine;

public class MuerteAreaExterior : MonoBehaviour
{
    public PlayerController jugador;
    public Boolean jugadorDentroNivel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentroNivel = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentroNivel = false;
            jugador.perderVida();
            jugador.perderVida();
            jugador.perderVida();
        }
    }
}
