using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo
    public float rotationSpeed = 2f;

    void Update()
    {
        // Hacemos que el planeta rote todo el rato sobre si mismo
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
    }
}

