using UnityEngine;
using System.Collections;

public class MovimientoEnemigos : MonoBehaviour
{
    public float velocidad = 2f; 
    public Transform puntoA; 
    public Transform puntoB; 
    private bool moviendoDerecha = true; 
    private bool enEspera = false; 
    private float tiempoGiro = 2f; 

    public Animator animator; 
    public PlayerController jugador; 
    public GameObject pantallaRoja; 

    private bool detenido = false; 

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
                    StartCoroutine(EsperarYGirar(puntoB));
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, puntoA.position, velocidad * Time.deltaTime);
                if (transform.position == puntoA.position)
                {
                    StartCoroutine(EsperarYGirar(puntoA));
                }
            }
        }
    }

    IEnumerator EsperarYGirar(Transform punto)
    {
        enEspera = true;
        float tiempo = 0f;

        while (tiempo < tiempoGiro)
        {
            float paso = 180f * (Time.deltaTime / tiempoGiro); // Paso gradual para los 180º
            transform.Rotate(Vector3.up, paso, Space.Self); // Rotación local en Y
            tiempo += Time.deltaTime;
            yield return null; // Espera 1 frame
        }

        moviendoDerecha = !moviendoDerecha; // Cambia la dirección
        enEspera = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugador.perderVida();
            animator.SetBool("muerto", true);
            StartCoroutine(EfectoMuerte(other.gameObject));
            detenido = true;
        }
    }

    IEnumerator EfectoMuerte(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            jugador.isMovingForward = !jugador.isMovingForward;
            if (jugador.currentSpeed > 2)
            {
                jugador.currentSpeed -= 2;
            }
        }

        pantallaRoja.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        pantallaRoja.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
