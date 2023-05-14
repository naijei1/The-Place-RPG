using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    private enum BattleStates
    {
        PlayersTurn, //Players will be able to choose their actions like healing or attacking
        EnemysTurn, //Enemy attcks
        GameWon, //Won the Battle
        GameLost, //Lost the Battle
    }
    private BattleStates State;
    [SerializeField] GameObject playerUi;
    [SerializeField] GameObject playerHeart;
    private GameObject[] EnemiesInBattle;
    private BattleController BattleController;
    private bool Delay = false;
    void Start()
    {
        BattleController = GameObject.FindGameObjectWithTag("BattleController").GetComponent<BattleController>();
        PlayerTurn();
        EnemiesInBattle = GameObject.FindGameObjectsWithTag("Enemy");
    }
    public void PlayerTurn()
    {
        State = BattleStates.PlayersTurn;
        playerUi.SetActive(true);
        playerHeart.SetActive(false);
    }
    public void Enemyturn()
    {
        playerUi.SetActive(false);
        playerHeart.SetActive(true);
        foreach(GameObject Enemy in EnemiesInBattle)
        {
            Enemy.GetComponent<BasicEnemyController>().StartAttack();
        }
        State = BattleStates.EnemysTurn;
        Invoke("DelayForCheckProjectile", 1);
    }
    private void DelayForCheckProjectile()
    {
        Delay = true;
    }
    private void Update()
    {
        if (State == BattleStates.EnemysTurn)
        {
            if(BattleController.AmountOfProjectile <= 0 && Delay)
            {
                PlayerTurn();
                Delay = false;
            }
        }
    }
}
