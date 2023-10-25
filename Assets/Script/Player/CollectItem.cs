using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    float magnet = 5.0f;
    float magnetStr = 10.0f;
    int magnetDir = 1;
    Transform playerTransform;
    Rigidbody2D playerRb;
    Transform itemTransform;
    bool magnetZone;

    private void Awake()
    {
        playerTransform = transform;
        playerRb = playerTransform.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (magnetZone && itemTransform != null)
        {
            Vector2 dirToPlayer = playerTransform.position - itemTransform.position;
            float distance = Vector2.Distance(playerTransform.position, itemTransform.position);
            float magnetDistanceStr = (magnetStr / distance) * magnet;
            Vector2 force = magnetDistanceStr * dirToPlayer.normalized * magnetDir;
            itemTransform.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CollectableItem")
        {
            itemTransform = collision.transform;
            magnetZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "CollectableItem")
        {
            magnetZone = false;
            itemTransform = null;
        }
    }
    /*float magnet = 5.0f;
    float magnetStr = 10.0f;
    int magnetDir = 1;
    Transform playerTransform;
    Rigidbody2D playerRb;
    Transform itemTransform;
    bool magnetZone;

    private void Awake()
    {
        playerTransform = transform;
        playerRb = playerTransform.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (magnetZone)
        {
            Vector2 dirToplayer = itemTransform.position -  playerTransform.position;
            float distance = Vector2.Distance(playerTransform.position, itemTransform.position);
            float magnetDistanceStr = (magnetStr / distance) * magnet;
            playerRb.AddForce(magnetDistanceStr * (dirToplayer * magnetDir), ForceMode2D.Force);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CollectableItem")
        {
            itemTransform = collision.transform;
            magnetZone = true;
        }
    }*/
}
