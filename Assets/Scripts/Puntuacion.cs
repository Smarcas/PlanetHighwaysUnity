using UnityEngine;
using TMPro;
using System.Threading;

public class Puntuacion : MonoBehaviour
{
    public float puntos;
    private float tiempo;
    private TextMeshProUGUI texto;
    
    void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Cada segundo que pasa, sumamos 1 a tiempo
        tiempo += Time.deltaTime;

        // Cada 10 segundos, le restamos 50 puntos al contador y reseteamos el tiempo
        if (tiempo >= 10f)
        {
            if (puntos > 0)
            {
                puntos -= 50;
            }
            tiempo = 0f;
        }

        // Cambiamos el texto de la interfaz (con "0" solo mostramos la parte entera de los puntos)
        texto.text = puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }
}
