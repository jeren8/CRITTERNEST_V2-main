using UnityEngine;

public class SPAWNER_VV2 : MonoBehaviour
{
    public GameObject enemigo;
    public int cantidadEnemigos = 10;

    void Start()
    {
        for (int i = 0; i < cantidadEnemigos; i++)
        {
            Vector3 direccion = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                0
            );

            Vector3 posicionSpawn =
                transform.position + direccion * 3f;

            GameObject nuevoEnemigo = Instantiate(
                enemigo,
                posicionSpawn,
                Quaternion.identity
            );

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
}
