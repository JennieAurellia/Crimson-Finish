using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{
    public TransformData playerPositonData;

    public void LoadPosition()
    {
        transform.position = playerPositonData.position;        
    }

    public void SavePosition(Vector2 newPosition)
    {
        playerPositonData.position  = newPosition;
    }

    #region Condition
    Vector2 playerCurrentPos;
    Vector2 currentCheckpointPos;

    public void OnCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPos = newCheckpointPosition;
        SavePosition(currentCheckpointPos);
    }
    public void OnEnemy()
    {
        ChangePlayerPos(currentCheckpointPos);
    }
    #endregion

    #region Instruction
    private void ChangePlayerPos(Vector2 newPosition)
    {
        transform.position = newPosition;
    }
    #endregion
}
