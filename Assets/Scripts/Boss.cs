using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public float speed;
    public int health = 10;
    private Transform playerPos;
    private Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

        Vector2 direction = new Vector2(player.x, player.y);

        this.transform.up = direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.health = 0;
            Debug.Log(player.health);
            Destroy(gameObject);
        }
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            health--;
            if (health == 0)
            {
                Destroy(gameObject);
                player.bossKills++;
            }
        }
    }
}