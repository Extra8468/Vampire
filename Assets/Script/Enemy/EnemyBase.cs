using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    PlayerBase player;
    private void Awake()
    {
        player = FindAnyObjectByType<PlayerBase>();
    }
}
