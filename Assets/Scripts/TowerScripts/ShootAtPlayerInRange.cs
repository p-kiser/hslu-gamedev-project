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

    // projectile related stuff
    GameObject[] projectiles;
    Rigidbody[] rbs;
    [SerializeField]
    private int MAX_PROJECTILES = 10;
    [SerializeField]
    private float INTERVAL = 1.0f;
    private float timer;
    bool wait;
    int index;
    

    // Start is called before the first frame update
    void Start()
    {
        // load the guns
        projectiles = new GameObject[MAX_PROJECTILES];
        rbs = new Rigidbody[MAX_PROJECTILES];

        for (int i = 0; i < MAX_PROJECTILES; i++) {
            projectiles[i] = Instantiate(bullet) as GameObject;
            rbs[i] = projectiles[i].GetComponent<Rigidbody>();
        }
        index = 0; timer = 0; wait = false;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(target.transform.position, transform.position);

        if (target != null && distance <= distanceToPlayer)
        {
            timer += 1.0F * Time.deltaTime;
            if (timer >= INTERVAL) {
                timer = 0.0f;
                wait = !wait;
            }

            if (!wait) { Shoot(); }
            // Reset the velocity and "pause" the physics


            /* old legacy code, kept here as a warning to young codeurs:
             
            GameObject bullets = Instantiate(bullet) as GameObject;
            bullets.transform.position = transform.position;

            Rigidbody rb = bullets.GetComponent<Rigidbody>();
            rb.AddForce((target.transform.position - transform.position) * bulletSpeed);
            */
            
        }
    }

    void Shoot() {
        rbs[index].velocity = Vector3.zero;
        rbs[index].angularVelocity = Vector3.zero;
        rbs[index].isKinematic = true;
        // Do positioning, etc
        projectiles[index].transform.position = rbs[index].position;
        projectiles[index].transform.rotation = Quaternion.identity;
        // Re-enable the physics and set start position to that of the turret
        rbs[index].isKinematic = false;
        projectiles[index].transform.position = transform.position;

        // shoot projectile and increase the counter
        rbs[index].AddForce((target.transform.position - transform.position) * bulletSpeed);

        Debug.Log("Shooteded a projectile called: " + index);
        index = ++index % MAX_PROJECTILES;
    }
}
