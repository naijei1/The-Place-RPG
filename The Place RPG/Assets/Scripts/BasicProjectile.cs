using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    [SerializeField] int barrier = 30;
    [SerializeField] float speed = 1;
    private BattleController BattleController;

    private void Awake()
    {
        BattleController = GameObject.FindGameObjectWithTag("BattleController").GetComponent<BattleController>();
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
        if (transform.position.x < -barrier || transform.position.x > barrier)
        {
            BattleController.AmountOfProjectile -= 1;
            Destroy(gameObject);
        }
        if (transform.position.y < -barrier || transform.position.y > barrier)
        {
            BattleController.AmountOfProjectile -= 1;
            Destroy(gameObject);
        }
    }
}
