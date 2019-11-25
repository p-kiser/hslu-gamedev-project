using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayerInRange : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float distanceToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(target.transform.position, transform.position);

        if (target != null && distance <= distanceToPlayer)
        {
            GameObject bullets = Instantiate(bullet) as GameObject;
            bullets.transform.position = transform.position;
            Rigidbody rb = bullets.GetComponent<Rigidbody>();
            rb.AddForce((target.transform.position - transform.position) * bulletSpeed);
        }

    }
}
