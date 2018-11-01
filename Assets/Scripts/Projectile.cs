using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    int age = 0;
    private Vector2 target;
    public float speed;

    private void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        if (age > 100) { Destroy(gameObject); }
        else { age++; }
    }

    private void FixedUpdate()
    {
        this.transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
