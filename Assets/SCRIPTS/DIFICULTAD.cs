using UnityEngine;

public class DIFICULTAD : MonoBehaviour
{
    public int dificultad = 1;

    void Start()
    {
        switch (dificultad)
        {
            case 1:
                Debug.Log("Dificultad: Fácil");
                break;

            case 2:
                Debug.Log("Dificultad: Normal");
                break;

            case 3:
                Debug.Log("Dificultad: Difícil");
                break;

            default:
                Debug.Log("Dificultad no válida");
                break;
        }
    }
}
