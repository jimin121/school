using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBot : MonoBehaviour
{
    public Transform target;
    private Vector3 destination;
    private NavMeshAgent agent;

    private AudioSource hitSound;
    private bool isdead;
    public int score = 1;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        hitSound = GetComponent<AudioSource>();
        target = GameObject.Find("Player").transform;
        isdead = false;
        destination = target.transform.position;
        agent.speed = 15f;
    }

    private void Update()
    {
        if (isdead || GameManager.instance.isGameover)
        {
            return;
        }

        destination = target.transform.position;
        agent.destination = destination;

    }
    
    public void OnHit()
    {
        isdead = true;

        GameManager.instance.AddScore(score);
        Hide();
        PlaySound();

        Destroy(gameObject, 0.5f);
    }

    private void PlaySound()
    {
        hitSound.Play();
    }

    private void Hide()
    {
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.OnGameOver();
        }
    }
}
