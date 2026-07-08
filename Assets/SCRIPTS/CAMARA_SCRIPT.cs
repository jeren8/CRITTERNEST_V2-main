using UnityEngine;

public class CAMARA_SCRIPT : MonoBehaviour
{
    public Transform jugador;
    
    void Update()
    {
        transform.position = new Vector3(jugador.position.x, jugador.position.y, -10f);

        if (transform.position.x < -5.5f)
        {
            transform.position = new Vector3(-5.5f, transform.position.y, transform.position.z);
        }
    }
}
