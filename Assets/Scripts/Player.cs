using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;
    public int health = 10;

    public float x;
    public float y;

    public Text healthDisplay;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public GameObject gun;
    public int zombieKills = 0;
    public int bossKills = 0;

    public Text zombieDisplay;
    public Text bossDisplay;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        x = this.transform.position.x;
        y = this.transform.position.y;
    }

    void Update()
    {

        healthDisplay.text = "HEALTH: " + health;
        zombieDisplay.text = "ZOMBIE KILLS: " + zombieKills;
        bossDisplay.text = "BOSS KILLS: " + bossKills;


        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        x = this.transform.position.x;
        y = this.transform.position.y;

        Facing();

    }

    private void Facing()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - gun.transform.position.x, mousePosition.y - gun.transform.position.y);

        gun.transform.up = direction;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

      


}
