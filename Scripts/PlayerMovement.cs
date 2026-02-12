using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5f;
    private float jumpStrenght = 8f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        var x = horizontalInput * speed * Time.deltaTime;
        var xyz = new Vector3(x, 0f, 0f);
        transform.Translate(xyz);

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            var y = new Vector2(0f, jumpStrenght);
            rb.AddForce(y, ForceMode2D.Impulse);
        }
    }
}
