using UnityEngine;

public class SPWANER : MonoBehaviour
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
        //crea (instancia) un enemigo en la escena.
        GameObject nuevoEnemigo = Instantiate(
    enemigo,
    posicionSpawn,
    Quaternion.identity
    
        );
        Debug.Log(nuevoEnemigo.name);
        Enemigo e = nuevoEnemigo.GetComponent<Enemigo>();

        if (e == null)
        {
            Debug.Log("El enemigo no tiene el script Enemigo.");
            return;
        }

        GameObject jugador = GameObject.Find("Personaje_Zock");

        if (jugador == null)
        {
            Debug.Log("No se encontró Personaje_Zock.");
            return;
        }

        e.jugador = jugador.transform;
    }
}
