using UnityEngine;
using UnityEngine.UI;
public class BarraVida : MonoBehaviour
{
    public VIDA_JUGADOR jugador;
    public Image barraVida;

    public int vidaMaxima = 200;

    void Update()
    {
        barraVida.fillAmount =
            (float)jugador.vida / vidaMaxima;
    }
}
