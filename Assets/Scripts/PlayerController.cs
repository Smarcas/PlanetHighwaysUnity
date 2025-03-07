using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    //[SerializeField] private Animator animator;
    
    private float groundCheckRadius = 0.3f;
    public float currentSpeed = 0f;
    public float maxSpeed = 13f;
    public float minSpeed = 0f;
    // Velocidad de aceleración
    public float acceleration = 3f;
    // Velocidad de desaceleración
    public float deceleration = 5f;
    public float turnSpeed = 1500f;
    public float jumpForce = 500f;
    public bool isMovingForward = true;
    public bool isMoving = false;
    public bool isGrounded;

    public UnityEvent<int> cambioVida;
    public int vidaMaxima = 3;
    public int vidaActual = 3;

    private Rigidbody playerRB;
    private Vector3 playerDirection;

    private GravityBody newGravity;
    public GameObject menuPausa;
    public bool menuPausaActivo = false;
    
    void Start()
    {
        groundMask = LayerMask.GetMask("Ground");
        playerRB = transform.GetComponent<Rigidbody>();
        newGravity = transform.GetComponent<GravityBody>();
        vidaActual = vidaMaxima;
        cambioVida.Invoke(vidaActual);
    }

    void Update()
    {
        playerDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
        // animator.SetBool("isJumping", !isGrounded);

        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    playerRB.AddForce(-newGravity.GravityDirection * jumpForce, ForceMode.Impulse);
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPausaActivo = !menuPausaActivo;
            menuPausa.SetActive(menuPausaActivo);
        }
    }
    
    void FixedUpdate()
    {
        // Si el personaje se está moviendo al menos a 0,1 de velocidad, ya contamos como que se está moviendo
        if (playerDirection.magnitude > 0.1f || currentSpeed > 0)
        {
            isMoving = true;
        } else {
            isMoving = false;
        }
        

        // Lógica de aceleración y frenado
        // Si presionamos la W, aceleramos hacia delante, si presionamos la S, va hacia atrás, con una serie de condiciones:
        if (isMoving && (Input.GetKey(KeyCode.W) || Gamepad.current.rightTrigger.ReadValue() > 0.1f))
        {
            if (!isMovingForward)
            {
                currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.fixedDeltaTime, minSpeed);
                if (currentSpeed <= minSpeed + 0.5f) { isMovingForward = true; }
            }
            else if (isMovingForward)
            {
                currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.fixedDeltaTime, maxSpeed);
                isMovingForward = true;
            }
        }
        else if (isMoving && (Input.GetKey(KeyCode.S) || Gamepad.current.leftTrigger.ReadValue() > 0.1f))
        {
            if (isMovingForward)
            {
                currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.fixedDeltaTime, minSpeed);
                if (currentSpeed <= minSpeed + 0.5f) { isMovingForward = false; }
            }
            else if (!isMovingForward) // Solo ir marcha atrás si está completamente detenido
            {
                currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.fixedDeltaTime, maxSpeed / 2);
            }
        }
        // Desaceleración si no se presiona ninguna tecla (hasta llegar a 0)
        else
        {
            currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.fixedDeltaTime, minSpeed);
            if (currentSpeed <= minSpeed + 0.5f) isMovingForward = true;
        }

        // --- Movimiento y rotación ---
        if (isMoving && currentSpeed > 0)
        {
            Vector3 direction = transform.forward * (isMovingForward ? 1 : -1);
            playerRB.MovePosition(playerRB.position + direction * (currentSpeed * Time.fixedDeltaTime));

            // Volvemos a multiplicar por (isMovingForward ? 1 : -1) para que el coche gire en la dirección correcta cuando vamos marcha atrás
            Quaternion rightDirection = Quaternion.Euler(0f, playerDirection.x * (isMovingForward ? 1 : -1) * (turnSpeed * Time.fixedDeltaTime), 0f);
            Quaternion newRotation = Quaternion.Slerp(playerRB.rotation, playerRB.rotation * rightDirection, Time.fixedDeltaTime * 3f);
            playerRB.MoveRotation(newRotation);
        }

        // animator.SetBool("isMoving", isMoving && currentSpeed > 0);
    }

    public void perderVida() {
        if (vidaActual > 0) {
            vidaActual--;
        }
        cambioVida.Invoke(vidaActual);
    }

    public void curarVida() {
        if (vidaActual < vidaMaxima) {
            vidaActual++;
        }
        cambioVida.Invoke(vidaActual);
    }
}
