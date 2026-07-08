using UnityEngine;

public class DASH : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadDash = 12f;
    public float tiempoDash = 0.2f;

    private float tiempoActual;

    void Update()
    {
        Vector3 direccion = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direccion.y = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direccion.y = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direccion.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direccion.x = 1;
        }

        direccion = direccion.normalized;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            tiempoActual = tiempoDash;
        }

        if (tiempoActual > 0)
        {
            transform.position += direccion * velocidadDash * Time.deltaTime;
            tiempoActual -= Time.deltaTime;
        }
        else
        {
            transform.position += direccion * velocidad * Time.deltaTime;
        }
    }
}
