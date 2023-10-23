using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBase : MonoBehaviour
{
    #region ½ºÅÝ
    float speed = 2.0f;
    public float Speed => speed;

    float damage = 5.0f;
    public float Damage => damage;

    float hp => 100.0f;
    public float HP => hp;

    float attackSpeed = 5.0f;
    public float AttackSpeed => attackSpeed;

    float gainRange = 20.0f;
    public float GainRange => gainRange;

    float reduce = 3.0f;
    public float Reduce => reduce;
    #endregion
    Animator playerAni;
    SpriteRenderer playerSR;
    Vector3 dir = Vector3.zero;

    PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        playerAni = GetComponent<Animator>();
        playerSR = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        transform.position += Time.deltaTime * speed * dir;
    }
    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        dir = value;
        if (dir.x == 0 && dir.y == 0)
        {
            playerAni.SetBool("IsMove", false);
        }
        else
        {
            playerAni.SetBool("IsMove", true);
            if (value.x < 0)
            {
                playerSR.flipX = true;
            }
            else if(value.x > 0)
            {
                playerSR.flipX = false;
            }
        }
    }
}
