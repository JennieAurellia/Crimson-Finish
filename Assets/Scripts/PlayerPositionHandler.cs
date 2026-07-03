using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{
    public TransformData playerPositonData;
    [SerializeField] private AudioSource coinClip;
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
    public void OnCoin(GameObject col)
    {
        coinClip.Play();
        Destroy(col);
    }

    public void OnFinish()
    {
        if (GameManager.Instance.levelCurrent == 2)
        {
            GameManager.Instance.ChangeScene(GameManager.Instance.levelCurrent);
        }
        else
        {
            GameManager.Instance.levelCurrent += 1;
            GameManager.Instance.ChangeLevel(GameManager.Instance.levelCurrent);
            GameManager.Instance.ChangeScene(GameManager.Instance.levelCurrent);
        }
    }
    #endregion

    #region Instruction
    private void ChangePlayerPos(Vector2 newPosition)
    {
        transform.position = newPosition;
    }
    #endregion
}
