using UnityEngine;

public class SPWANER : MonoBehaviour
{
    public GameObject enemigo;

    public int maxGeneraciones = 5; // Total de enemigos que puede generar
    private int enemigosGenerados = 0;

    void Start()
    {
        InvokeRepeating("Generar", 1f, 3f);
    }

    void Generar()
    {
        // Si ya llegó al límite, deja de generar
        if (enemigosGenerados >= maxGeneraciones)
        {
            CancelInvoke("Generar");
            return;
        }

        Vector3 direccion = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0
        );

        Vector3 posicionSpawn = transform.position + direccion * 3f;

        GameObject nuevoEnemigo = Instantiate(
            enemigo,
            posicionSpawn,
            Quaternion.identity
        );

        enemigosGenerados++;

        Enemigo e = nuevoEnemigo.GetComponent<Enemigo>();

        if (e != null)
        {
            GameObject jugador = GameObject.Find("Personaje_Zock");

            if (jugador != null)
            {
                e.jugador = jugador.transform;
            }
        }
    }
}
