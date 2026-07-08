using UnityEngine;

public class BALA_ENEMY : MonoBehaviour
{
    public float velocidad = 5f;

    Transform jugador;
    Vector3 direccion;

    void Start()
    {
        jugador = GameObject.Find("Personaje_Zock").transform;

        direccion = jugador.position - transform.position;
        direccion = direccion.normalized;
    }

    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime;

        if (Vector3.Distance(transform.position, jugador.position) < 0.3f)
        {
            Destroy(gameObject);
        }
    }
}
