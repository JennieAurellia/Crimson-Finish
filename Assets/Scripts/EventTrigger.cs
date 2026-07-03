using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TypeTag
{
    Player,
    Trap,
    Checkpoint,
    Finish,
    Trigger,
    Enemy,
    Coin,
    Flag
}

public class EventTrigger : MonoBehaviour
{
    public TypeTag targetTag;
    public UnityEvent<GameObject> onTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag.ToString())
        {
            onTrigger.Invoke(collision.gameObject);
        }
    }
}
