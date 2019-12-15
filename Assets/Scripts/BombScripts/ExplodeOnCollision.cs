using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollision : MonoBehaviour
{
    [SerializeField]
    private float power = 10.0f;
    [SerializeField]
    private float radius = 20.0f;
    [SerializeField]
    private float upForce = 1.0f;
    [SerializeField]
    private float timeToDetonation = 1.0f;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
           if (collision.rigidbody != null)
        {
            Invoke("Detonate", timeToDetonation);
        }
    }

    void Detonate()
    {
        Vector3 explosionPosition = gameObject.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponentInParent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("Hit a rigidbody");
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                Debug.Log("Bomb exploded and dies now, RIP");
                GameObject.Destroy(gameObject);
            }
        }
    }

        
 }
