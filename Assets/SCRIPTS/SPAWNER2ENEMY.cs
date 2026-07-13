using UnityEngine;

public class SPAWNER2ENEMY : MonoBehaviour
{
    public GameObject enemigo;

    public int maxGeneraciones = 5;
    private int enemigosGenerados = 0;

    void Start()
    {
        InvokeRepeating("Generar", 1f, 3f);
    }

    void Generar()
    {
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

        ENEMIGO_DISPARA e = nuevoEnemigo.GetComponent<ENEMIGO_DISPARA>();

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
