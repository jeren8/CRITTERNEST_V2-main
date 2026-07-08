using UnityEngine;

public class SPAWNER_ATTACK : MonoBehaviour
{
    public Transform jugador;
    public float velocidad = 3f;

    void Update()
    {
        if (jugador != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                jugador.position,
                velocidad * Time.deltaTime
            );
        }
    }
}
