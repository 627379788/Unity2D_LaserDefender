using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    Vector2 inputPosition;
    Vector2 maxBounds;
    Vector2 minBounds;
    
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingUp;
    [SerializeField] float paddingDown;
    [SerializeField] float moveSpeed = 5f;

    Shooter shooter;
    
    void Awake() {
        shooter = GetComponent<Shooter>();
    }

    void Start() {
        InitBounds();
    }
    void Update()
    {
        Move();
    }

    void InitBounds() {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Move()
    {
        Vector3 delta = inputPosition * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingDown, maxBounds.y - paddingUp);
        transform.position = newPos;
    }

    void OnMove(InputValue inputValue) {
        inputPosition = inputValue.Get<Vector2>();
    }

    void OnFire(InputValue inputValue) {
        shooter.isFiring = inputValue.isPressed;
    }
}
