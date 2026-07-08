using UnityEngine;

public class VARIOS_ENEMIGOS : MonoBehaviour
{
    public enum EstadoEnemigo
    {
        Idle,
        Chase,
        Attack,
        Dead
    }

    public EstadoEnemigo estadoActual;

    public Transform jugador;

    public float velocidad = 3f;
    public float distanciaDeteccion = 5f;
    public float distanciaAtaque = 1.5f;

    void Update()
    {
        ActualizarEstado();

        switch (estadoActual)
        {
            case EstadoEnemigo.Idle:
                Debug.Log("Estado: Idle");
                break;

            case EstadoEnemigo.Chase:
                Debug.Log("Estado: Chase");

                transform.position = Vector3.MoveTowards(
                    transform.position,
                    jugador.position,
                    velocidad * Time.deltaTime
                );
                break;

            case EstadoEnemigo.Attack:
                Debug.Log("Estado: Attack");
                Debug.Log("¡Atacando al jugador!");
                break;

            case EstadoEnemigo.Dead:
                Debug.Log("Estado: Dead");
                break;
        }
    }

    void ActualizarEstado()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= distanciaAtaque)
        {
            CambiarEstado(EstadoEnemigo.Attack);
        }
        else if (distancia <= distanciaDeteccion)
        {
            CambiarEstado(EstadoEnemigo.Chase);
        }
        else
        {
            CambiarEstado(EstadoEnemigo.Idle);
        }
    }

    void CambiarEstado(EstadoEnemigo nuevoEstado)
    {
        estadoActual = nuevoEstado;
    }
}
