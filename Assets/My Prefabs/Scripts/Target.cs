using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject FullBod;

    // Start is called before the first frame update
    public float health;

    public void TakeDamage(float amount)
    {
        
        
        health -= amount;
        Debug.Log(health);
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(FullBod);
    }
}
