using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatcherMovement : MonoBehaviour
{
    [SerializeField] Slider movementControl;
    [SerializeField] float minLimit;
    [SerializeField] float maxLimit;
    [SerializeField] GameObject player;
    private float playerX;

    private void Start()
    {
        movementControl.minValue = player.transform.position.y + minLimit;
        movementControl.maxValue = player.transform.position.y + maxLimit;
        playerX = player.transform.position.x;
    }
    private void Update()
    {
        // move on y axis only
        if (movementControl != null)
        {
            player.transform.position = new Vector2(playerX, movementControl.value);
        }
    }

    public void CatcherReset()
    {
        movementControl.value = 0;
    }
}
