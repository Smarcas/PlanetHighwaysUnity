using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;
    private int currentCameraIndex = 0;

    void Start()
    {
        // La cámara inicial será MainCamera (en la posición 0 del array)
        SwitchCamera(currentCameraIndex);
    }

    void Update()
    {
        // Cambiamos la cámara al presionar 5
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentCameraIndex++;
            if (currentCameraIndex >= cameras.Length)
            {
                // Una vez que hemos pasado por todas las camaras del array, reseteamos a la primera
                currentCameraIndex = 0;
            }
            SwitchCamera(currentCameraIndex);
        }
    }

    private void SwitchCamera(int index)
    {
        // Desactivar todas las cámaras excepto la seleccionada
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }
    }
}
