using UnityEngine;

public class VICTORIA : MonoBehaviour
{
    public GameObject panelVictoria;

    void Start()
    {
        panelVictoria.SetActive(false);
    }

    public void Ganar()
    {
        panelVictoria.SetActive(true);

        Time.timeScale = 0f;

        Debug.Log("GANASTE");
    }
}
