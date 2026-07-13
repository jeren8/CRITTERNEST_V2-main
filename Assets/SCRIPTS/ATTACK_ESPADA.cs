using UnityEngine;

public class ATTACK_ESPADA : MonoBehaviour
{
    public int danio = 25;

    private BoxCollider2D hitbox;

    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        hitbox.enabled = false;
    }

    public void ActivarHitBox()
    {
        hitbox.enabled = true;
    }

    public void DesactivarHitBox()
    {
        hitbox.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            // Enemigo cuerpo a cuerpo
            VIDA_ENEMIGO vida = other.GetComponent<VIDA_ENEMIGO>();

            if (vida != null)
            {
                vida.RecibirDanio(danio);
            }

            // Enemigo a distancia
            VIDA_ENEMIGO_DISPARA vidaDistancia =
                other.GetComponent<VIDA_ENEMIGO_DISPARA>();

            if (vidaDistancia != null)
            {
                vidaDistancia.RecibirDanio(danio);
            }

            // Boss
            VIDA_BOSS vidaBoss =
                other.GetComponent<VIDA_BOSS>();

            if (vidaBoss != null)
            {
                vidaBoss.RecibirDanio(danio);
            }
        }
    }
}       
