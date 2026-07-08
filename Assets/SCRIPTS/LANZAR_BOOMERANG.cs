using UnityEngine;

public class LANZAR_BOOMERANG : MonoBehaviour
{
    public GameObject boomerangPrefab;
    public Transform firePoint;

    void Update()
    {
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
}
