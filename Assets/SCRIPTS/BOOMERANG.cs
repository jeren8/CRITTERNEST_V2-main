using UnityEngine;

public class BOOMERANG : MonoBehaviour
{
    public float velocidad = 5f;
    public Transform jugador;

    Vector3 inicio;
    bool regresar;

    void Start()
    {
        inicio = transform.position;
    }

    void Update()
    {
        if (!regresar)
        {
            // Avanza hacia la derecha
            transform.position += Vector3.right * velocidad * Time.deltaTime;

            // Cuando recorra 3 unidades, empieza a regresar
            if (Vector3.Distance(transform.position, inicio) > 3f)
            {
                regresar = true;
            }
        }
        else
        {
            // Calcula la dirección hacia el jugador
            Vector3 direccion = jugador.position - transform.position;
            direccion = direccion.normalized;

            // Se mueve hacia el jugador
            transform.position += direccion * velocidad * Time.deltaTime;

            // Si llega cerca del jugador, se destruye
            if (Vector3.Distance(transform.position, jugador.position) < 0.5f)
            {
                Destroy(gameObject);
            }
        }
    }
}
    