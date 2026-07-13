using TMPro;
using UnityEngine;

public class CONTADOR_ENEMIGOS : MonoBehaviour
{
    public static CONTADOR_ENEMIGOS instancia;

    public int enemigosDerrotados = 0;

    public TextMeshProUGUI texto;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        ActualizarTexto();
    }

    public void EnemigoDerrotado()
    {
        enemigosDerrotados++;

        ActualizarTexto();

        Debug.Log("Enemigos derrotados: " + enemigosDerrotados);
    }

    void ActualizarTexto()
    {
        texto.text = "Enemigos: " + enemigosDerrotados;
    }
}
