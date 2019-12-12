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
    private float RATE_OF_FIRE = 0.25f;
    [SerializeField]
    private float INTERVAL = 2.0f;
    private float timer;
    bool wait;
    bool shooted = false;
    int index;
    

    // Start is called before the first frame update
    void Start()
    {
        // load the guns
        projectiles = new GameObject[MAX_PROJECTILES];
        rbs = new Rigidbody[MAX_PROJECTILES];

        for (int i = 0; i < MAX_PROJECTILES; i++) {
            projectiles[i] = Instantiate(bullet) as GameObject;
            projectiles[i].transform.position = Vector3.down * 999;
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
            

            if (!wait) {
                // Reset the velocity and "pause" the physics

                /* old legacy code, kept here as a warning to young codeurs:
             
                GameObject bullets = Instantiate(bullet) as GameObject;
                bullets.transform.position = transform.position;

                Rigidbody rb = bullets.GetComponent<Rigidbody>();
                rb.AddForce((target.transform.position - transform.position) * bulletSpeed);
                */

                if (!shooted) {
                    Shoot(index);
                    index = ++index % MAX_PROJECTILES;
                    //shooted = true;
                    Invoke("ToggleShooted", RATE_OF_FIRE);
                } 
                
            }
        }
    }

    void Shoot(int i) {
        rbs[i].velocity = Vector3.zero;
        rbs[i].angularVelocity = Vector3.zero;
        rbs[i].isKinematic = true;
        // Do positioning, etc
        projectiles[i].transform.position = rbs[i].position;
        projectiles[i].transform.rotation = Quaternion.identity;
        // Re-enable the physics and set start position to that of the turret
        rbs[i].isKinematic = false;
        projectiles[i].transform.position = transform.position;
        projectiles[i].SetActive(true);

        // shoot projectile and increase the counter
        rbs[index].AddForce((target.transform.position - transform.position) * bulletSpeed);

        Debug.Log("Shooteded a projectile called: " + index);
    }

    void ToggleShooted() { shooted = !shooted; }
}
