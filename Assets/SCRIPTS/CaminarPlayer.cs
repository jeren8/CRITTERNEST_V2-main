using UnityEngine;
using UnityEngine.InputSystem;

public class CaminarPlayer : MonoBehaviour
{
    public float velocidad = 5f;
    public Animator animator;

    public float velocidadDash = 12f;
    public float tiempoDash = 0.2f;

    public ATTACK_ESPADA espada;

    private Rigidbody2D rb;

    Vector3 escalaOriginal;

    private bool atacando = false;
    private bool muerto = false;

    private bool haciendoDash = false;
    private float tiempoActualDash = 0f;
    private Vector2 direccionDash;

    void Start()
    {
        escalaOriginal = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Si murió, no hace absolutamente nada
        if (muerto)
        {
            return;
        }

        Vector2 movimiento = Vector2.zero;

        if (Keyboard.current.wKey.isPressed) movimiento.y += 1;
        if (Keyboard.current.sKey.isPressed) movimiento.y -= 1;
        if (Keyboard.current.aKey.isPressed) movimiento.x -= 1;
        if (Keyboard.current.dKey.isPressed) movimiento.x += 1;

        // DASH
        if (Keyboard.current.leftShiftKey.wasPressedThisFrame && !haciendoDash)
        {
            haciendoDash = true;
            tiempoActualDash = tiempoDash;

            animator.SetTrigger("Dash");

            if (movimiento != Vector2.zero)
            {
                direccionDash = movimiento.normalized;
            }
            else
            {
                direccionDash = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
            }
        }

        // Movimiento
        if (haciendoDash)
        {
            rb.MovePosition(
                rb.position +
                direccionDash * velocidadDash * Time.deltaTime
            );

            tiempoActualDash -= Time.deltaTime;

            if (tiempoActualDash <= 0)
            {
                haciendoDash = false;
            }
        }
        else
        {
            rb.MovePosition(
                rb.position +
                movimiento.normalized * velocidad * Time.deltaTime
            );
        }

        // Animator
        animator.SetFloat("MOVEMENT", movimiento.magnitude);
        animator.SetBool("atacando", atacando);

        // Girar personaje
        if (movimiento.x > 0)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(escalaOriginal.x),
                escalaOriginal.y,
                escalaOriginal.z
            );
        }
        else if (movimiento.x < 0)
        {
            transform.localScale = new Vector3(
                -Mathf.Abs(escalaOriginal.x),
                escalaOriginal.y,
                escalaOriginal.z
            );
        }

        // Ataque
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            atacando = true;
        }
    }

    public void ActivarHitBox()
    {
        if (!muerto)
        {
            espada.ActivarHitBox();
        }
    }

    public void DesactivarHitBox()
    {
        espada.DesactivarHitBox();
    }

    public void DesactivaAtaque()
    {
        atacando = false;
    }

    public void Morir()
    {
        muerto = true;

        haciendoDash = false;
        atacando = false;
        tiempoActualDash = 0f;

        rb.linearVelocity = Vector2.zero;

        animator.SetFloat("MOVEMENT", 0);
        animator.SetBool("atacando", false);

        enabled = false;
    }
}