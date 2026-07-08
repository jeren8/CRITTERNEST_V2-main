using UnityEngine;

public class VIDA_JUGADOR : MonoBehaviour
{
    public int vida = 100;

    private Animator animator;
    private CaminarPlayer caminarPlayer;
    private bool muerto = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        caminarPlayer = GetComponent<CaminarPlayer>();
    }

    public void RecibirDanio(int danio)
    {
        if (muerto)
        {
            return;
        }

        vida -= danio;

        if (vida < 0)
        {
            vida = 0;
        }

        Debug.Log("Vida jugador: " + vida);

        if (vida <= 0)
        {
            muerto = true;

            Debug.Log("GAME OVER");

            animator.SetTrigger("muerto");

            caminarPlayer.enabled = false;
        }
    }

    public void Curar(int cantidad)
    {
        if (muerto)
        {
            return;
        }

        vida += cantidad;

        if (vida > 100)
        {
            vida = 100;
        }

        Debug.Log("Vida jugador: " + vida);
    }

    public bool EstaMuerto()
    {
        return muerto;
    }
}
