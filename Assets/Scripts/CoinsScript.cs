using UnityEngine;

public class CoinsScript : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float cantPuntos = 100f;
    [SerializeField] private Puntuacion puntuacion;

    void Update()
    {
        // Hacemos que el planeta rote todo el rato sobre si mismo
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puntuacion.SumarPuntos(cantPuntos);
            Destroy(gameObject);
        }
    }
}
