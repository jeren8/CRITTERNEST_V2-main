using UnityEngine;

public class VIDA_BOSS : MonoBehaviour
{
    public int vida = 300;
    public VICTORIA victoria;
    public void RecibirDanio(int danio)
    {
        vida -= danio;

        Debug.Log("Vida Boss: " + vida);

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
        if (vida <= 0)
        {
            victoria.Ganar();

            Destroy(gameObject);
        }
    }
}
