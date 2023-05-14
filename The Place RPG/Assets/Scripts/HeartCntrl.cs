using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCntrl : MonoBehaviour
{
    private static float DefaultSpeed = 0.06f;

    [SerializeField] private float HeartSpeed = DefaultSpeed;
    private Vector3 StartingPos = Vector3.zero;
    private float Sensitivity = 0.1f;
    private Vector2 MovePos;

    [SerializeField] private float MaxX = 2;
    [SerializeField] private float MaxY = 2;
    [SerializeField] private float MinX = -2;
    [SerializeField] private float MinY = -2;
    private void OnEnable()
    {
        SetHeart();
    }
    private void SetHeart()
    {
        transform.position = StartingPos;
        MovePos = StartingPos;
    }

    private void Update() {
        Sensitivity = Mathf.Max(0.01f, Input.GetKey(KeyCode.X) ? HeartSpeed / 2.0f : HeartSpeed);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * Sensitivity;
        float vertical = Input.GetAxisRaw("Vertical") * Sensitivity;

        MovePos.x += horizontal;
        MovePos.y += vertical;

        MovePos.x = Mathf.Clamp(MovePos.x, MinX, MaxX);
        MovePos.y = Mathf.Clamp(MovePos.y, MinY, MaxY);
        
        transform.position = MovePos;
    }
}
