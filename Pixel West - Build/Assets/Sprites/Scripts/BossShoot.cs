using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
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

    public GameObject BossRun;

    float speed = 15f;

    public Transform fence1;
    
    public Transform fence2;
    bool trigger = true;
    private SpriteRenderer sprite_renderer;

    void Start()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
        bullets = bulletSlot;
        anim = gameObject.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        sprite_renderer.enabled = true;
        time += Time.deltaTime;
        if (time > timeToShoot && bullets > 0)
        {
            float dist = Vector3.Distance(other.position, transform.position);
            if (dist < range)
            {
                Shoot();
            }
        }
        if (bullets < 1)
        {
            float dista = Vector3.Distance(fence1.position, transform.position);
            float dista2 = Vector3.Distance(fence2.position, transform.position);
            sprite_renderer.enabled = false;
            if (trigger)
            {
                Vector3 TargetPosition = new Vector3(fence2.transform.position.x, transform.position.y, fence2.transform.position.z);
                transform.LookAt(TargetPosition);
            }
            if (dista < 3)
            {
                Vector3 TargetPosition = new Vector3(fence2.transform.position.x, transform.position.y, fence2.transform.position.z);
               transform.LookAt(TargetPosition);
                trigger = false;
            }
            if (dista2 < 3)
            {
                Vector3 TargetPosition = new Vector3(fence1.transform.position.x, transform.position.y, fence1.transform.position.z);
                transform.LookAt(TargetPosition);
                trigger = false;
            }
           
            BossRun.SetActive(true);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);


            if (time > timeToReload)
            {
                bullets = bulletSlot;
            }
        }
        else
        {
            Vector3 TargetPosition = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            BossRun.SetActive(false);
            transform.LookAt(TargetPosition);
            transform.Translate(Vector3.forward * Time.deltaTime * 0);
        }
    }
    void Shoot()
    {
        anim.SetTrigger("EnemyShoot");
        RaycastHit hit;
        audio.PlayOneShot(audio.clip);
        trigger = true;
        if (Physics.Raycast(transform.position, shootPoint.transform.forward, out hit, range))
        {

            //Debug.Log(hit.transform.name);
            // Debug.Log(hit.transform.position);
            time = time - time;
            bullets = bullets - 1;
            PlayerHealth player = hit.transform.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }

        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "fence")
        {
            speed = -speed;
        }
    }*/
}
