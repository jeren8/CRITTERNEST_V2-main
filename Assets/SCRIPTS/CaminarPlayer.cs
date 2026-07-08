using UnityEngine;
using UnityEngine.InputSystem;

public class CaminarPlayer : MonoBehaviour
{
    public float velocidad = 5f;
    public float distanciaAtaque = 1.5f;
    public int danio = 25;
    public Animator animator;

    public float velocidadDash = 12f;
    public float tiempoDash = 0.2f;

    private Rigidbody2D rb;

    Vector3 escalaOriginal;
    private bool atacando = false;

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
                if (transform.localScale.x > 0)
                    direccionDash = Vector2.right;
                else
                    direccionDash = Vector2.left;
            }
        }

        // Movimiento normal o Dash
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
        if (Input.GetMouseButtonDown(0))
        {
            atacando = true;
            Atacar();
        }
    }

    void Atacar()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");

        foreach (GameObject enemigo in enemigos)
        {
            float distancia = Vector2.Distance(
                transform.position,
                enemigo.transform.position
            );

            if (distancia <= distanciaAtaque)
            {
                VIDA_ENEMIGO vida = enemigo.GetComponent<VIDA_ENEMIGO>();

                if (vida != null)
                {
                    vida.RecibirDanio(danio);
                }
            }
        }
    }

    public void DesactivaAtaque()
    {
        atacando = false;
    }
}