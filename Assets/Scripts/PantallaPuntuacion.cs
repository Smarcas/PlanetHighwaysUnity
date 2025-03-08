using UnityEngine;
using TMPro;

public class PantallaPuntuacion : MonoBehaviour
{
    public float puntuacionFinal = 0;
    public float tiempoFinal = 0;
    private TextMeshProUGUI texto;
    
    void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        texto.text = "Has superado el nivel" + "\nPuntuación obtenida: " + puntuacionFinal.ToString("0") + "\nTiempo: " + tiempoFinal.ToString() + "\nVolviendo al menú principal...";
    }
}
