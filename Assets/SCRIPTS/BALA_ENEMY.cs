using UnityEngine;

public class BALA_ENEMY : MonoBehaviour
{
    public float velocidad = 5f;
    public int danio = 10;

    Transform jugador;
    Vector3 direccion;

    void Start()
    {
        GameObject personaje = GameObject.Find("Personaje_Zock");

        if (personaje != null)
        {
            jugador = personaje.transform;

            direccion = jugador.position - transform.position;
            direccion = direccion.normalized;
        }
    }

    void Update()
    {
        if (jugador == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position += direccion * velocidad * Time.deltaTime;

        if (Vector3.Distance(transform.position, jugador.position) < 0.3f)
        {
            VIDA_JUGADOR vidaJugador =
                jugador.GetComponent<VIDA_JUGADOR>();

            if (vidaJugador != null)
            {
                vidaJugador.RecibirDanio(danio);
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            VIDA_JUGADOR vidaJugador =
                other.GetComponent<VIDA_JUGADOR>();

            if (vidaJugador != null)
            {
                vidaJugador.RecibirDanio(danio);
            }

            Destroy(gameObject);
        }

        if (other.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
    }
}
