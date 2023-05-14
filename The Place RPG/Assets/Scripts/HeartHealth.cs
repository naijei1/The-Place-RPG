using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealth : MonoBehaviour
{
    private float Health = 20f;
    private float MaxHealth = 20f;
    public void TakeDMG(float Damage)
    {
        Health -= Damage;
        if(Health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Player dead");
    }
    void Update()
    {
        
    }
}
