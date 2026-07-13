using UnityEngine;

public class ENEMIGO_DISPARA : MonoBehaviour
{

    public Transform jugador;
    public GameObject bala;

    public float velocidad = 2f;

    public float distanciaDeteccion = 7f;
    public float distanciaAtaque = 4f;
    public float distanciaMinima = 2f;

    public float tiempoDisparo = 2f;

    private float contador = 0;

    private Animator animator;
    private Rigidbody2D rb;

    private bool enMovimiento = false;
    private bool Atacando = false;

    private Vector3 escalaOriginal;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        escalaOriginal = transform.localScale;
    }

    void FixedUpdate()
    {
        if (jugador == null)
            return;

        float distancia = Vector2.Distance(transform.position, jugador.position);

        Vector2 direccion =
            (jugador.position - transform.position).normalized;

        enMovimiento = false;
        Atacando = false;

        // Se acerca al jugador
        if (distancia > distanciaAtaque &&
            distancia <= distanciaDeteccion)
        {
            rb.MovePosition(
                rb.position + direccion * velocidad * Time.fixedDeltaTime
            );

            enMovimiento = true;
        }
        // Retrocede si el jugador está demasiado cerca
        else if (distancia < distanciaMinima)
        {
            rb.MovePosition(
                rb.position - direccion * velocidad * Time.fixedDeltaTime
            );

            enMovimiento = true;
        }

        // Girar hacia el jugador
        if (jugador.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(escalaOriginal.x),
                escalaOriginal.y,
                escalaOriginal.z
            );
        }
        else
        {
            transform.localScale = new Vector3(
                -Mathf.Abs(escalaOriginal.x),
                escalaOriginal.y,
                escalaOriginal.z
            );
        }

        animator.SetBool("enMovimiento", enMovimiento);
        animator.SetBool("Atacando", Atacando);
    }

    void Update()
    {
        if (jugador == null)
            return;

        float distancia = Vector2.Distance(transform.position, jugador.position);

        if (distancia <= distanciaAtaque)
        {
            contador += Time.deltaTime;

            Atacando = true;
            animator.SetBool("Atacando", true);

            if (contador >= tiempoDisparo)
            {
                Instantiate(
                    bala,
                    transform.position,
                    Quaternion.identity
                );

                contador = 0;
            }
        }
        else
        {
            animator.SetBool("Atacando", false);
        }
    }

    public void DesactivaAtaque()
    {
        Atacando = false;
        animator.SetBool("Atacando", false);
    }
}
