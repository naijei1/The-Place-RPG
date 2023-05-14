using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    
    public static float DefaultSpeed = 0.06f;

    [SerializeField] private float HeartSpeed = DefaultSpeed;
    private float Sensitivity = 0.1f;
    private Vector2 MovePos;

    void Start() {
        this.SetHeart();   
    }

    private void SetHeart() {
        MovePos = Vector2.zero;
    }

    void Update() {
        Sensitivity = Mathf.Max(0.01f, Input.GetKey(KeyCode.X) ? HeartSpeed / 2.0f : HeartSpeed);
    }

    private void FixedUpdate() {
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * Sensitivity;
        float verticalMovement = Input.GetAxisRaw("Vertical") * Sensitivity;

        MovePos.x += horizontalMovement;
        MovePos.y += verticalMovement;

        transform.position = MovePos;
    }
}
