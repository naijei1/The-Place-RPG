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
    private BattleController BattleController;
    private int CharacterAmount; //Used for spacing out Characters
    private bool Delay = false;
    private GameObject[] EnemiesInBattle;
    [SerializeField] GameObject playerUi;
    [SerializeField] GameObject playerHeart;
    [SerializeField] private GameObject[] CharacterAvatar; //The character on the screen
    [SerializeField] private string[] CharactersToSpawn; //What characters will be spawned in
    [SerializeField] private Vector3 CharacterSpawnSpotTop;
    [SerializeField] private Vector3 CharacterSpawnSpotTopMiddle;
    [SerializeField] private Vector3 CharacterSpawnSpotMiddle;
    [SerializeField] private Vector3 CharacterSpawnSpotMiddleBottom;
    [SerializeField] private Vector3 CharacterSpawnSpotBottom;

    void Start()
    {
        spawnCharaters();
        BattleController = GameObject.FindGameObjectWithTag("BattleController").GetComponent<BattleController>();
        PlayerTurn();
        EnemiesInBattle = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void spawnCharaters()
    {
        int index = 0;

        CharacterAmount = CharactersToSpawn.Length;
        foreach (var i in CharactersToSpawn)
        {
            switch (i)
            {
                case "Naijei":
                    Debug.Log("Naijei Choosen and was " + index);
                    InstantiateCharaters(index, 0);
                    break;

                case "Drill":
                    Debug.Log("Drill Choosen and was " + index);
                    InstantiateCharaters(index, 1);
                    break;

                case "Vitro":
                    Debug.Log("Vitro Choosen and was " + index);
                    InstantiateCharaters(index, 2);
                    break;

                //Add more here

                default:
                    Debug.LogError(i + " is not a vaild player");
                    break;
            }
            index++;
        }
    }

    private void InstantiateCharaters(int PlayerOrder, int CharacterId)
    {
        switch (CharacterAmount)
        {
            case 1: //Only 1 player in team
                Instantiate(CharacterAvatar[CharacterId], CharacterSpawnSpotMiddle, transform.rotation);
                break;

            case 2: //2 players in team
                if(PlayerOrder == 0)
                {
                    Instantiate(CharacterAvatar[CharacterId], CharacterSpawnSpotTopMiddle, transform.rotation);
                }else
                if(PlayerOrder == 1)
                {
                    Instantiate(CharacterAvatar[CharacterId], CharacterSpawnSpotMiddleBottom, transform.rotation);
                }
                break;

            case 3: //3 players in a team
                if (PlayerOrder == 0)
                {
                    Instantiate(CharacterAvatar[CharacterId], CharacterSpawnSpotTop, transform.rotation);
                }
                else if (PlayerOrder == 1)
                {
                    Instantiate(CharacterAvatar[CharacterId], CharacterSpawnSpotMiddle, transform.rotation);
                }
                else if (PlayerOrder == 2)
                {
                    Instantiate(CharacterAvatar[CharacterId], CharacterSpawnSpotBottom, transform.rotation);
                }
                break;

            default:
                Debug.LogError(CharacterAmount + " is invaid, >3 or <0");
                break;
        }
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
        Invoke("DelayForCheckProjectile", 5);
    }
    private void DelayForCheckProjectile() //This makes sure that there is a delay before checking amount of projectiles in the scene. 
    {
        Delay = true;
    }
    private void Update()
    {
        if (State == BattleStates.EnemysTurn) //If there is no projectiles left it means enemy turn is over.
        {
            if(BattleController.AmountOfProjectile <= 0 && Delay)
            {
                PlayerTurn();
                Delay = false;
            }
        }
    }
}
