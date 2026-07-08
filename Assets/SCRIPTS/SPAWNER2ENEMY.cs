using UnityEngine;

public class SPAWNER2ENEMY : MonoBehaviour
{
    public GameObject enemigo;

    void Start()
    {
        InvokeRepeating("Generar", 1f, 3f);
    }

    void Generar()
    {
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

        ENEMIGO_DISPARA e = nuevoEnemigo.GetComponent<ENEMIGO_DISPARA>();

        if (e == null)
        {
            Debug.LogError("Enemy2 no tiene el script ENEMIGO_DISPARA.");
            return;
        }

        GameObject jugador = GameObject.Find("Personaje_Zock");

        if (jugador == null)
        {
            Debug.LogError("No se encontró Personaje_Zock.");
            return;
        }

        e.jugador = jugador.transform;
    }
}
