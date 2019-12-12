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
    ParticleSystem parti;
    Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        health = MAX_HEALTH;

        rb = GetComponent<Rigidbody>();
        parti = GetComponent<ParticleSystem>();
        parti.Stop();
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (onSpeed) { Shake(); }

    }

    // collisions
    void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.tag);

        // collectables
        if (other.gameObject.CompareTag("Coin")) {
            points++;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("HealthPotion")) {
            health++;
            other.gameObject.SetActive(false);

        }
        if (other.gameObject.CompareTag("SpeedPotion")) {
            onSpeed = true;
            other.gameObject.SetActive(false);
            Invoke("SoberUp", SPEED_UPGRADE_TIME);
        }
        if (other.gameObject.CompareTag("InvincibilityPotion")) {
            BecomeImmortal();
            other.gameObject.SetActive(false);
            Invoke("BecomeMortal", INVINCIBILITY_TIME);
        }
        // damage
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log("Enemy collision");
            TakeDamage(1);
        }
        if (other.gameObject.CompareTag("Deathzone")) {
            Debug.Log("You failed.");
            Respawn();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spike")) {
            TakeDamage(1);
        }
    }

    // score related stuff
    public int GetPoints() { return points; }
    public void AddPoint(int points) { this.points += points; }

    // health related stuff
    public int GetHealth() { return health; }
    public void TakeDamage(int damage) {
        health -= damage * GetDamageMultiplicator();
        if (health <= 0) Respawn();
    }

    private void Respawn() {
        // TODO: Juicy animation
        rb.velocity = rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        transform.position = initPos;
        transform.rotation = Quaternion.identity;
        rb.isKinematic = false;
        health = MAX_HEALTH;
        ResetStatus();
    }

    // power up
    public int GetSpeedMultiplicator() { return onSpeed ? SPEED_UPGRADE : 1; }
    public bool IsOnSpeed() { return onSpeed; }
    private void SoberUp() { onSpeed = false;  }

    public bool IsInvincible() { return invincible;  }

    private void BecomeImmortal() {
        invincible = true;
        parti.Play();
        
    }
    private void BecomeMortal() {
        invincible = false;
        parti.Stop();
    }
    public int GetDamageMultiplicator() { return invincible ? 0 : 1;  }

    // special effects
    private void Shake() {
        Vector3 pos = transform.position;
        float shake = Mathf.Sin(Time.time * 100) * 0.1f;
        transform.position = pos + new Vector3(shake, shake, shake);
    }

    private void ResetStatus() {
        BecomeMortal();
        SoberUp();

    }
}