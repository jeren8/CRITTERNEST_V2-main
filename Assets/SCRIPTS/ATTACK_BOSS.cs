using UnityEngine;

public class ATTACK_BOSS : MonoBehaviour
{
    public int danio = 15;

    private BoxCollider2D hitbox;

    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        hitbox.enabled = false;
    }


    // Evento de animación cuando empieza el golpe
    public void ActivarHitBox()
    {
        hitbox.enabled = true;
        Debug.Log("Ataque Boss ACTIVADO");
    }


    // Evento de animación cuando termina el golpe
    public void DesactivarHitBox()
    {
        hitbox.enabled = false;
        Debug.Log("Ataque Boss DESACTIVADO");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            VIDA_JUGADOR vida =
                other.GetComponent<VIDA_JUGADOR>();

            if (vida != null)
            {
                vida.RecibirDanio(danio);

                Debug.Log("Boss hizo 15 de daño");
            }
        }
    }
}
