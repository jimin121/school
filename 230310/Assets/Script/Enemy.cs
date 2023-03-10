using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 destination;
    private AudioSource hitSound;

    private bool isdead;
    public float enemySpeed;
    public float enemyHP;

    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        hitSound = GetComponent<AudioSource>();
        destination = GameObject.Find("Player").transform.position;
        isdead = false;
    }

    private void UpdatePosition()
    {

    }

    private void OnHit()
    {

    }

    private void Die()
    {

    }

    private void Hide()
    {
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
    }


}
