using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float damage = 10f;
    
    public int bulletSlot;
    int bullets;
    public float timeToReload;

    public float timeToShoot;

    public Transform shootPoint;
    float time;

    Animator anim;
    public float range = 100f;
    private AudioSource audio;

    public Transform other;

    void Start()
    {
        bullets = bulletSlot;
        anim = gameObject.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        
        time += Time.deltaTime;
        if (time > timeToShoot && bullets > 0)
        {
            float dist = Vector3.Distance(other.position, transform.position);
            if (dist < range)
            {
                Shoot();
            }
        }
        if (bullets<1)
        {
            
            if (time > timeToReload)
            {
                bullets = bulletSlot;
            }
        }
    }
    void Shoot()
    {
        anim.SetTrigger("EnemyShoot");
        RaycastHit hit;
        audio.PlayOneShot(audio.clip);
        if (Physics.Raycast(transform.position, shootPoint.transform.forward, out hit, range))
        {
        
          //Debug.Log(hit.transform.name);
          // Debug.Log(hit.transform.position);
            time = time-time;
            bullets = bullets - 1;
            PlayerHealth player = hit.transform.GetComponent<PlayerHealth>();

            if (player != null)
            {
               player.TakeDamage(damage);
            }
            
        }
    }
}
