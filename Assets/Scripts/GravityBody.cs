using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    public static float GRAVITY_FORCE = 800;
    
    // Creamos un vector con la dirección de la gravedad
    public Vector3 GravityDirection
    {
        get
        {
            // Si estamos dentro de más de un campo gravitatorio, comparamos las prioridades para que se ajuste a la que queramos
            if (gravityAreas.Count == 0) return Vector3.zero;
            gravityAreas.Sort((area1, area2) => area1.Priority.CompareTo(area2.Priority));
            return gravityAreas.Last().GetGravityDirection(this).normalized;
        }
    }

    private Rigidbody playerRB;
    private List<GravityArea> gravityAreas;

    void Start()
    {
        playerRB = transform.GetComponent<Rigidbody>();
        gravityAreas = new List<GravityArea>();
    }
    
    void FixedUpdate()
    {
        // Aplicamos la fuerza de la gravedad, en la dirección de la gravedad, como una aceleración (y no una fuerza lineal)
        playerRB.AddForce(GravityDirection * (GRAVITY_FORCE * Time.fixedDeltaTime), ForceMode.Acceleration);

        // Ajustamos la rotación del personaje para que coincida con la del planeta
        Quaternion upRotation = Quaternion.FromToRotation(transform.up, -GravityDirection);
        Quaternion newRotation = Quaternion.Slerp(playerRB.rotation, upRotation * playerRB.rotation, Time.fixedDeltaTime * 3f);;
        playerRB.MoveRotation(newRotation);
    }

    // Métodos que nos permiten determinar qué áreas actuan como campo de gravedad del personaje
    public void AddGravityArea(GravityArea gravityArea)
    {
        gravityAreas.Add(gravityArea);
    }

    public void RemoveGravityArea(GravityArea gravityArea)
    {
        gravityAreas.Remove(gravityArea);
    }
}