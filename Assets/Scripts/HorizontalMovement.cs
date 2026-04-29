using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class HorizontalMovement : MonoBehaviour
{
    static float t = 0;
    public float distance;
    public float speed;
    private float originalPos;
    public UnityEvent<GameObject> onTrigger;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        originalPos = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MovementHor();
    }

    private void MovementHor()
    {
        t += Time.deltaTime * speed;
        var x = originalPos + math.sin(t) * distance;

        var currPos = transform.position.x;
        if (currPos == originalPos - distance)
        {
            spriteRenderer.flipX = true;
        }
        else if (currPos == originalPos + distance)
        {
            spriteRenderer.flipX = false;
        }

        transform.position = new Vector2(x, transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.y > transform.position.y + 0.5f)
            {
                Die();
            }
            else
            {
                onTrigger.Invoke(collision.gameObject);
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
