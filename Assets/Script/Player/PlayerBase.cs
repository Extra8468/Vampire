using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBase : MonoBehaviour
{
    #region 스텟
    float speed = 2.0f;
    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    /// <summary>
    /// 
    /// </summary>
    float damage = 5.0f;
    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    /// <summary>
    /// 현재 체력
    /// </summary>
    float hp = 100.0f;
    public float HP
    {
        get => hp;
        set => hp = value;
    }

    float maxHP;
    public float MaxHP
    {
        get => maxHP;
        set => maxHP = value;
    }

    /// <summary>
    /// 공격속도(weapon 쿨타임)
    /// </summary>
    float attackSpeed = 5.0f;
    public float AttackSpeed 
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }

    /// <summary>
    /// 아이템 습득 범위
    /// </summary>
    float gainRange = 20.0f;
    public float GainRange
    {
        get => gainRange;
        set => gainRange = value;
    }

    float reduce = 3.0f;
    public float Reduce => reduce;
    #endregion
    Animator playerAni;
    SpriteRenderer playerSR;
    CircleCollider2D getItem;
    Vector3 dir = Vector3.zero;

    PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        getItem = GetComponent<CircleCollider2D>();
        playerAni = GetComponent<Animator>();
        playerSR = GetComponent<SpriteRenderer>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "CollectableItem")
        {
            Destroy(collision.gameObject);
        }
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
