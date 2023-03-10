using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private MeshRenderer targetMesh;
    private SphereCollider targetCollider;
    private Rigidbody targetrigidbody;
    public float destroyTime = 4;
    private int targetscore = 1;

    private AudioSource targetHitSound;

    private void Awake()
    {
        targetCollider = GetComponent<SphereCollider>();
        targetMesh = GetComponent<MeshRenderer>();

        targetrigidbody = GetComponent<Rigidbody>();
        targetHitSound = GetComponent<AudioSource>();
        

        Destroy(gameObject, destroyTime);
    }
    public void TargetOnHit()
    {
        GameManager.instance.AddScore(targetscore);
        PlaySound();
        Hide();
        Destroy(gameObject, 0.5f);       
    }
    void PlaySound()
    {
       targetHitSound.Play();
    }

    private void Hide()
    {
        targetMesh.enabled = false;
        targetCollider.enabled = false;
    }
}
