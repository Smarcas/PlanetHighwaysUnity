using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovimientoEnemigos : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad del enemigo
    public Transform puntoA; // Punto inicial
    public Transform puntoB; // Punto final
    private bool moviendoDerecha = true; // Para alternar entre las direcciones
    private bool enEspera = false; // Controla si está esperando
    private float tiempoGiro = 2f; // Duración del giro en segundos
    private float tiempoGiroRestante = 0f; // Tiempo restante para completar el giro

    public Animator animator; // Referencia al Animator
    public PlayerController jugador; // Referencia al script del jugador
    public GameObject coche; // Referencia al coche
    public GameObject pantallaRoja; // Referencia a la imagen de pantalla roja
    public float fuerzaRebote = 5f; // Fuerza para el rebote del coche

    private bool rotando = false; // Variable para controlar la rotación
    private float anguloInicial; // Ángulo inicial antes de la rotación
    private bool detenido = false; // Para controlar si el enemigo está detenido

    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = puntoA.position;
    }

    void Update()
    {
        if (!enEspera && !detenido)
        {
            if (moviendoDerecha)
            {
                transform.position = Vector3.MoveTowards(transform.position, puntoB.position, velocidad * Time.deltaTime);
                if (transform.position == puntoB.position)
                {
                    StartCoroutine(EsperarYGirar());
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, puntoA.position, velocidad * Time.deltaTime);
                if (transform.position == puntoA.position)
                {
                    StartCoroutine(EsperarYGirar());
                }
            }
        }
        else
        {
            if (rotando)
            {
                if (tiempoGiroRestante > 0)
                {
                    tiempoGiroRestante -= Time.deltaTime; // Reduce el tiempo restante
                    float t = 1 - (tiempoGiroRestante / tiempoGiro); // Normaliza el tiempo para la interpolación
                    float anguloObjetivo = anguloInicial + 180f; // Ángulo objetivo es el ángulo inicial + 180 grados
                    transform.rotation = Quaternion.Lerp(Quaternion.Euler(0f, anguloInicial, 0f), Quaternion.Euler(0f, anguloObjetivo, 0f), t); // Interpolación suave
                }
                else
                {
                    rotando = false; // Detiene la rotación después de 2 segundos
                }
            }
        }
    }

    IEnumerator EsperarYGirar()
    {
        enEspera = true;
        anguloInicial = transform.rotation.eulerAngles.y; // Guardamos el ángulo inicial antes de la rotación
        tiempoGiroRestante = tiempoGiro; // Reinicia el tiempo para el giro
        rotando = true; // Inicia el proceso de rotación
        yield return new WaitForSeconds(2f); // Espera 2 segundos en la posición

        // Realiza el giro (esto solo se ejecuta una vez)
        Girar();

        enEspera = false;
    }

    void Girar()
    {
        moviendoDerecha = !moviendoDerecha; // Cambia la dirección
        tiempoGiroRestante = tiempoGiro; // Reinicia el tiempo para el giro
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto con el que colisiona tiene el tag "Coche"
        {
            // Llama al método "PerderVida" en el Player si es necesario
            jugador.perderVida(); // Llama al método perderVida() del Player
            
            animator.SetBool("muerto", true); // Cambia el parámetro "muerto" a true en el Animator
            StartCoroutine(EfectoMuerte(other.gameObject)); // Llama al efecto de muerte

            // Detener al enemigo antes de hacer la animación de muerte
            detenido = true;
        }
    }

    // Corutina para el efecto de muerte
    IEnumerator EfectoMuerte(GameObject other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto con el que colisiona tiene el tag "Coche"
        {
            // Cambiamos la direccion del coche a la opuesta
            jugador.isMovingForward = !jugador.isMovingForward;
            if (jugador.currentSpeed > 2)
            {
                jugador.currentSpeed -= 2;
            }
        }

        // Muestra la pantalla roja durante 1 segundo
        pantallaRoja.SetActive(true);
        yield return new WaitForSeconds(1f);
        pantallaRoja.SetActive(false);

        // Esperamos a que la animación de muerte termine
        yield return new WaitForSeconds(0.5f); // Tiempo suficiente para completar la animación de muerte

        Destroy(gameObject); // Elimina al enemigo después de que termine la animación
    }

}
