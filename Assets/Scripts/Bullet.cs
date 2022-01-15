using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionParticles;

    public Light bulletLight;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 2f);
    }

    private void Update()
    {
        bulletLight.intensity = Mathf.Lerp(bulletLight.intensity, 0, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Transform explosionPoint = transform;

        Instantiate(explosionParticles, explosionPoint);

        if(collision.gameObject.CompareTag("AI"))
        {
            collision.gameObject.GetComponent<AIMover>().life = 0;
            Destroy(gameObject);
        }
    }
}
