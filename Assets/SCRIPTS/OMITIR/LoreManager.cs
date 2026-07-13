using UnityEngine;
using UnityEngine.SceneManagement;

public class LoreManager : MonoBehaviour
{
    public string juegoCritternest = "juegoCritternest";

    public void Continuar()
    {
        SceneManager.LoadScene(juegoCritternest);
    }
}
