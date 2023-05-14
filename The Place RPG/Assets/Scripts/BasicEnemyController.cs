using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] AttackScripts;

    public void StartAttack()
    {
        int RandomAttack = Random.Range(0, AttackScripts.Length);
        AttackScripts[RandomAttack].Invoke("Attack", 0);
    }
}
