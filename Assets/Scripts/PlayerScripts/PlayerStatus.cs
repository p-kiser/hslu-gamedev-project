using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    private int MAX_HEALTH = 5;
    private int SPEED_UPGRADE = 2;
    private float SPEED_UPGRADE_TIME = 5.0f;
    private float INVINCIBILITY_TIME = 10.0f;

    int points;
    int health;

    bool onSpeed = false;
    bool invincible = false;


    Rigidbody rb;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        health = 3;

        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        if (onSpeed) { Shake(); }

    }

    // collisions
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);

        // collectables
        if (other.gameObject.CompareTag("Coin"))
        {
            points++;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("HealthPotion")) {
            health++;
            other.gameObject.SetActive(false);

        }
        if (other.gameObject.CompareTag("SpeedPotion"))
        {
            onSpeed = true;
            other.gameObject.SetActive(false);
            Invoke("SoberUp", SPEED_UPGRADE_TIME);
        }
        if (other.gameObject.CompareTag("InvincibilityPotion"))
        {
            invincible = true;
            other.gameObject.SetActive(false);
            Invoke("BecomeMortal", INVINCIBILITY_TIME);
        }
        // damage
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy collision");
            TakeDamage(1);
        }

        if (other.gameObject.CompareTag("Deathzone"))
        {
            Debug.Log("You failed.");
            Respawn();
        }
    }

    // helper functions
    public int GetPoints() { return points; }
    public void AddPoint(int points) { this.points += points; }
    private void Respawn() {

        // TODO: Juicy animation

        // reset position etc.
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        // Re-enable the physics and set start position to that of the turret
        rb.isKinematic = false;
        //transform.position = transform.position;

        // reset health
        health = MAX_HEALTH;
    }
    public int GetHealth() { return health; }
    public void TakeDamage(int damage)
    {
        health -= damage * GetDamageMultiplicator();
        if (health <= 0) Respawn();
    }
    public int GetSpeedMultiplicator() { return onSpeed ? SPEED_UPGRADE : 1; }
    public bool IsOnSpeed() { return onSpeed; }
    private void SoberUp() { onSpeed = false;  }

    public bool IsInvincible() { return invincible;  }
    private void BecomeMortal() { invincible = false;  }
    public int GetDamageMultiplicator() { return invincible ? 0 : 1;  }

    private void Shake() {
        Vector3 pos = transform.position;
        float shake = Mathf.Sin(Time.time * 100) * 0.1f;
        transform.position = pos + new Vector3(shake, shake, shake);
    }
}