using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShooting : MonoBehaviour
{
    public int WeaponNumber;

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    public int bulletSlot;
    public Text bulletSlotCount;
    int bullets;
    public Text bulletCount;

    public float timeToReload;

    public float timeToShoot;
    Animator anim;
  
    float time;

    public GameObject impactEffect;

    public float randomInnacuracy;
    private AudioSource audio;
  
 

   void Start()
    {
        bullets = bulletSlot;
        anim = gameObject.GetComponent<Animator>();
        bulletSlotCount.text = bulletSlot.ToString();
        audio = GetComponent<AudioSource>();
       
    }
    void Update()

    {
       
        if(time > 0.45)
        {
            
            anim.SetTrigger("BackIdle");
            
        }
        
        if (bullets < 1)
        {
            anim.SetTrigger("Reload");
            if (time > (timeToReload / 7)){
                anim.SetTrigger("Reloading");
                anim.ResetTrigger("Reload");
            }
            if (time > (timeToReload-0.5))
            {
                anim.SetTrigger("Reload Done");
                anim.ResetTrigger("Reloading");
                if (time > timeToReload)
                {
                    anim.SetTrigger("BackIdle");
                    anim.ResetTrigger("Reload Done");
                    bullets = bulletSlot;
                    time = time - time;
                }
            }
        }
        bulletCount.text = bullets.ToString();
        bulletSlotCount.text = bulletSlot.ToString();
        time += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            if (time > timeToShoot && bullets > 0)
            {
                Shoot();
            }
            if (bullets < 1)
            {
                anim.SetTrigger("Reload");
                if (time > (timeToReload / 7))
                {
                    anim.SetTrigger("Reloading");
                    anim.ResetTrigger("Reload");
                }
                if (time > (timeToReload - 0.5))
                {
                    anim.SetTrigger("Reload Done");
                    anim.ResetTrigger("Reloading");
                    if (time > timeToReload)
                    {
                        anim.SetTrigger("BackIdle");
                        anim.ResetTrigger("Reload Done");
                        bullets = bulletSlot;
                        time = time-time;
                    }
                }

            }
        }
       
    }

    void Shoot()
    {
        anim.SetTrigger("Active");
        anim.ResetTrigger("Reload Done");
        anim.ResetTrigger("Reloading");
        anim.ResetTrigger("Reload");
        anim.ResetTrigger("BackIdle");
        time = time - time;

        audio.PlayOneShot(audio.clip);

        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position + new Vector3(Random.Range(-randomInnacuracy, randomInnacuracy), Random.Range(-randomInnacuracy, randomInnacuracy), Random.Range(-randomInnacuracy, randomInnacuracy)), fpsCam.transform.forward, out hit, range))
        {
            
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();

            if(enemy !=null)
            {
                enemy.TakeDamage(damage);
            }

           GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.3f);
        }
        bullets = bullets - 1;
    }
}
