using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float range = 400f;
    public float fireRate = 0.2f;
    public ParticleSystem muzzleFlash;
    public Vector3 fineSightOriginPos;
    public Animator anim;

    public AudioClip fire_Sound;
}
