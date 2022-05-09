using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class player : MonoBehaviour
{

    public int MaxHealth = 100;
    public int current_Health = 0;

    public HealthBar healthBar;

    public GameOverScript gameOverScreen;
    
    

    // Start is called before the first frame update
    void Start()
    {
        current_Health = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }
    

    // Update is called once per frame
    void Update()
    {
        GetComponent<PlayerMovement>().FixedUpdate();
    }
    

    void TakeDamage(int damage)
    {
        current_Health -= damage;
        healthBar.SetHealth(current_Health);
        if(current_Health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "EnemySmol")
        {
            TakeDamage(20);
        }
    }

    private void Die()
    {
        gameOverScreen.Setup();
    }

}
