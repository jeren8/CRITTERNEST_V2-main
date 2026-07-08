using UnityEngine;

public class ENEMIGO_DISPARA : MonoBehaviour
{
    public Transform jugador;
    public GameObject bala;

    public float distanciaDeteccion = 5f;
    public float tiempoDisparo = 2f;

    float contador = 0;

    void Update()
    {
        if (jugador == null)
            return; 
        
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= distanciaDeteccion)
        {
            contador += Time.deltaTime;

            if (contador >= tiempoDisparo)
            {
                Instantiate(bala, transform.position, Quaternion.identity);
                contador = 0;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaDeteccion);
    }
}
