using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_Attack1 : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] int AmountToSpawn = 10;
    private BattleController BattleController;
    public void Attack()
    {
        BattleController = GameObject.FindGameObjectWithTag("BattleController").GetComponent<BattleController>();
        AmountToSpawn = 10;
        SummonBullet();
    }

    private void SummonBullet()
    {
        Instantiate(bullet, new Vector3(-10, Random.Range(-4, 4), 0) , bullet.transform.rotation);
        BattleController.AmountOfProjectile += 1;
        if(AmountToSpawn > 0)
        {
            AmountToSpawn -= 1;
            Invoke("SummonBullet", 1);
        }
    }
}
