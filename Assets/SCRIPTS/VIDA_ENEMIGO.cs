using UnityEngine;

public class VIDA_ENEMIGO : MonoBehaviour
{
    public int vida = 50;
    public int curacionJugador = 10;

    public void RecibirDanio(int danio)
    {
        vida -= danio;

        Debug.Log("Vida enemigo: " + vida);

        if (vida <= 0)
        {
            GameObject jugador = GameObject.Find("Personaje_Zock");

            if (jugador != null)
            {
                VIDA_JUGADOR vidaJugador =
                    jugador.GetComponent<VIDA_JUGADOR>();

                if (vidaJugador != null)
                {
                    vidaJugador.Curar(curacionJugador);
                }
            }

            Destroy(gameObject);
        }
    }
}
