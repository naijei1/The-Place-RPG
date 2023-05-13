using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCntrl : MonoBehaviour
{
    private Vector3 StartingPos = Vector3.zero;
    [SerializeField] private float HeartSpeed;
    [SerializeField] private float Sensitivity;
    private Vector2 MovePos;

    [SerializeField] private float MaxX = 2;
    [SerializeField] private float MaxY = 2;
    [SerializeField] private float MinX = -2;
    [SerializeField] private float MinY = -2;
    void Start()
    {
        SetHeart();
    }

    private void SetHeart()
    {
        transform.position = StartingPos;
        MovePos = StartingPos;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * Sensitivity;
        float vertical = Input.GetAxis("Vertical") * Sensitivity;

        MovePos.x += horizontal;
        MovePos.y += vertical;

        MovePos.x = Mathf.Clamp(MovePos.x, MinX, MaxX);
        MovePos.y = Mathf.Clamp(MovePos.y, MinY, MaxY);

        transform.position = Vector2.Lerp(transform.position, MovePos, HeartSpeed * Time.deltaTime);

    }
}
