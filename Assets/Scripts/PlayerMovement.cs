using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private AudioSource jumpSound;
    private Rigidbody2D rb;
    private float speed = 5f;
    public bool isPlayerWalk;
    private float jumpStrenght = 8f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkSFX());
    }

    private void PlayWalk(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }
        animator.SetTrigger("Go walk");
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        var x = horizontalInput * speed * Time.deltaTime;
        var xyz = new Vector3(x, 0f, 0f);
        transform.Translate(xyz);

        if (horizontalInput != 0) 
        {
            isPlayerWalk = true;
            PlayWalk(horizontalInput);
        }
        else
        {
            isPlayerWalk = false;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            jumpSound.Play();
            var y = new Vector2(0f, jumpStrenght);
            rb.AddForce(y, ForceMode2D.Impulse);
        }
    }

    IEnumerator WalkSFX()
    {
        while (true)
        {
            if (isPlayerWalk == true) walkSound.Play();

            yield return new WaitForSeconds(0.4f);
        }
    }
}
