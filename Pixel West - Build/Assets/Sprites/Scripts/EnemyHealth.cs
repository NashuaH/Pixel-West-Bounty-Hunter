using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;
    SpriteRenderer sprite;
    float time;
   public Image bar;
    

    float healthMax;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        healthMax = health;
       // bar = transform.Find("Bar");
    }

    void Update()
    {
        bar.fillAmount = health/healthMax;
        time += Time.deltaTime;
        if (time > 0.2)
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
    }

    public void TakeDamage (float amount)
    {
        time = 0;
        sprite.color = new Color(1, 0, 0, 1);
        health -= amount;
        
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject, 0.4f);
    }
}
