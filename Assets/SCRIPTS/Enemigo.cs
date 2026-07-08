        using UnityEngine;

    public class Enemigo : MonoBehaviour
    {
    public Transform jugador;
    public float velocidad = 3f;
    public float distanciaDeteccion = 5f;
    public int danio = 10;
    public float distanciaAtaque = 1f;

    private Animator animator;
    private VIDA_JUGADOR VIDA_JUGADOR;
    private float tiempoActual;

    public float tiempoEntreAtaques = 1f;

    private bool EnMovimiento = false;
    private bool Atacando = false;

    void Start()
    {
        VIDA_JUGADOR = jugador.GetComponent<VIDA_JUGADOR>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (jugador == null)
        {
            return;
        }

        if (VIDA_JUGADOR.EstaMuerto())
        {
            EnMovimiento = false;
            Atacando = false;

            animator.SetBool("EnMovimiento", EnMovimiento);
            animator.SetBool("Atacando", Atacando);

            return;
        }

        float distancia = Vector2.Distance(transform.position, jugador.position);

        if (distancia <= distanciaDeteccion && distancia > distanciaAtaque)
        {
            Vector3 direccion =
                (jugador.position - transform.position).normalized;

            transform.position +=
                direccion * velocidad * Time.deltaTime;

            EnMovimiento = true;
        }
        else
        {
            EnMovimiento = false;
        }

        animator.SetBool("EnMovimiento", EnMovimiento);
        animator.SetBool("Atacando", Atacando);

        tiempoActual -= Time.deltaTime;

        if (distancia <= distanciaAtaque &&
            tiempoActual <= 0)
        {
            Atacando = true;

            VIDA_JUGADOR.RecibirDanio(danio);
            tiempoActual = tiempoEntreAtaques;
        }
    }

    public void DesactivaAtaque()
    {
        Atacando = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            transform.position,
            distanciaDeteccion
        );
    }
}