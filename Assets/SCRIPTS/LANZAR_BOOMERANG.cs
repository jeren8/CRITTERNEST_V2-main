using UnityEngine;

public class LANZAR_BOOMERANG : MonoBehaviour
{
    public GameObject boomerangPrefab;
    public Transform firePoint;

    private bool muerto = false;

    void Update()
    {
        if (muerto)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = Instantiate(
                boomerangPrefab,
                firePoint.position,
                firePoint.rotation
            );

            b.GetComponent<BOOMERANG>().jugador = transform;
        }
    }

    public void Morir()
    {
        muerto = true;
    }
}
