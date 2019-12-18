using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    [SerializeField]
    AudioClip jumpSound;

    private int MAX_HEALTH = 5;
    private int SPEED_UPGRADE = 2;
    private float SPEED_UPGRADE_TIME = 5.0f;
    private float INVINCIBILITY_TIME = 10.0f;
    private float INVINCIBILLY_AFTER_HIT = 2.0f;

    int points;
    int health;
    int keysCollected = 0;

    bool onSpeed = false;
    bool invincible = false;

    Rigidbody rb;
    ParticleSystem parti;

    [SerializeField]
    private Transform startingPosition;
    public Transform RespawnPosition;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        health = MAX_HEALTH;

        rb = GetComponent<Rigidbody>();
        parti = GetComponent<ParticleSystem>();
        parti.Stop();
        // Move and rotate the Player to the start of the level
        transform.position = startingPosition.position;
        transform.rotation = startingPosition.rotation;
        // Set the start of the level as spawn point
        RespawnPosition = startingPosition;

        UiController.instance.UpdateUI();

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
            if (health < MAX_HEALTH)
            {
                health++;
                other.gameObject.SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("HealthPotionBig")) {
            health = MAX_HEALTH;
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

        // key
        //if (other.gameObject.CompareTag("Key")) {
        //    if (keysCollected <= 3) { keysCollected++; }
        //}

        // damage
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log("Enemy collision");
            TakeDamage(1);
        }
        if (other.gameObject.CompareTag("Deathzone")) {
            Debug.Log("You failed.");
            Respawn();
        }

        // reward for killing enemies
        if (other.gameObject.CompareTag("KilledEnemyReward"))
        {
            points += 2;
        }

        if (other.gameObject.CompareTag("KilledBigEnemyReward"))
        {
            points += 6;
        }

        UiController.instance.UpdateUI();

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spike")) {
            TakeDamage(1);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("EnemyBig"))
        {
            TakeDamage(2);
        }

    }

    // key related stuff
    public void CollectKey()
    {
        if (keysCollected <= 3) { keysCollected++; }
    }
    public int GetKeysCollected() { return keysCollected; }
    public bool AllKeysCollected() 
    {
        if (keysCollected == 3)
        {
            return true;
        } else if (keysCollected < 3)
        {
            return false;
        } else
        {
            return false;
        }
    }

    // score related stuff
    public int GetPoints() { return points; }
    public void AddPoint(int points) { this.points += points; }

    // health related stuff
    public int GetHealth() { return health; }
    public void TakeDamage(int damage) {

        if (!invincible) {
            health -= damage;
            if (health <= 0)
            {
                Respawn();
            }
            else {
                BecomeImmortal();
                Invoke("BecomeMortal", INVINCIBILLY_AFTER_HIT);
            }
        }

        UiController.instance.UpdateUI();

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

    // special effects
    private void Shake() {
        Vector3 pos = transform.position;
        float shake = Mathf.Sin(Time.time * 100) * 0.05f;
        transform.position = pos + new Vector3(shake, shake, shake);
    }

    private void ResetStatus() {
        BecomeMortal();
        SoberUp();
    }

    private void Respawn()
    {
        // TODO: Juicy animation
        rb.velocity = rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        transform.position = RespawnPosition.position;
        transform.rotation = RespawnPosition.rotation;
        rb.isKinematic = false;
        health = MAX_HEALTH;
        ResetStatus();

        UiController.instance.UpdateUI();

    }

}