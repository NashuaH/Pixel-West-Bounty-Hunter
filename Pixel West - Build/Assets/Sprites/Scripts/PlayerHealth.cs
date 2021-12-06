using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public GameObject damageSprite;
    bool damage = false;
    float time;

    public GameObject GameOverPanel;
    public PlayerMovement MoveScript;

    
    public Image Bar;
    bool gameOver = false;

    public void start()
    {
       
        MoveScript = GetComponent<PlayerMovement>();
    }
    public void Update()
    {
        Bar.fillAmount = (health / 200);

       
        if (damage)
        {
            damageSprite.SetActive(true);
            time += Time.deltaTime;
        }
        if (time > 0.2)
        {
            damageSprite.SetActive(false);
            damage = false;
            time = time - time;
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        damage = true;
        
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        gameOver = true;
        MoveScript.enabled = false;
        Time.timeScale = 0;
       
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameOverPanel.SetActive(true);
       
    }
}
