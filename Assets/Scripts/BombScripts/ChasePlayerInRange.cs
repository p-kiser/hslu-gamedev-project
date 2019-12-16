using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayerInRange : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distanceToPlayer = 20f;
    [SerializeField]
    private AudioClip sound;

    private bool soundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(target.transform.position, transform.position);

        if (target != null && distance <= distanceToPlayer)
        {
            if (!soundPlayed) {
                if (sound != null)
                {
                    AudioSource.PlayClipAtPoint(sound, gameObject.transform.position, 1.0f);
                    soundPlayed = true;
                }
            }
            agent.destination = target.transform.position;
        }
    }
}
