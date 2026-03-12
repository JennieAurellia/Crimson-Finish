using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTransformData", menuName = "Transform Data")]
public class TransformData : ScriptableObject
{
    public Vector2 position;

    public void ResetData()
    {
        position = new Vector2(1f, 1f);
    }
}
