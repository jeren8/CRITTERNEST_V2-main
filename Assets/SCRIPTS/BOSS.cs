using UnityEngine;

public class BOSS : MonoBehaviour
{
    public Transform jugador;

    public float velocidad = 2f;
    public float distanciaDeteccion = 10f;
    public float distanciaAtaque = 2f;

    public float tiempoEntreAtaques = 1.5f;

    public ATTACK_BOSS ataque;

    private Animator animator;

    private bool enMovimiento = false;
    private bool atacando = false;

    private float contadorAtaque = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (jugador == null)
            return;

        if (contadorAtaque > 0)
            contadorAtaque -= Time.deltaTime;

        float distancia = Vector2.Distance(
            transform.position,
            jugador.position
        );

        Vector3 direccion =
            (jugador.position - transform.position).normalized;

        enMovimiento = false;

        // Camina
        if (distancia <= distanciaDeteccion &&
            distancia > distanciaAtaque)
        {
            transform.position +=
                direccion * velocidad * Time.deltaTime;

            enMovimiento = true;
        }

        // Ataca solo cuando termina el tiempo de espera
        if (distancia <= distanciaAtaque &&
            contadorAtaque <= 0 &&
            !atacando)
        {
            atacando = true;
            contadorAtaque = tiempoEntreAtaques;

            animator.SetBool("Atacando", true);
        }

        animator.SetBool("enMovimiento", enMovimiento);

        // Girar
        if (jugador.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    // Animation Event
    public void ActivarHitBox()
    {
        ataque.ActivarHitBox();
    }

    // Animation Event
    public void DesactivarHitBox()
    {
        ataque.DesactivarHitBox();
    }

    // Animation Event al finalizar la animación
    public void FinalizarAtaque()
    {
        atacando = false;
        animator.SetBool("Atacando", false);
    }
}
