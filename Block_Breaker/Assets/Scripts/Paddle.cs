using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration paramaters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    // cached references
    private GameSession _gameSession;
    private Ball _ball;


    private void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
        _ball = FindObjectOfType<Ball>();
    }


    void Update()
    {
        MovePaddle();
    }


    private void MovePaddle()
    {
        Vector2 pos = transform.position;
        Vector2 paddlePos = new Vector2(pos.x, pos.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }


    private float GetXPos()
    {
        if (_gameSession.IsAutoPlayEnabled())
        {
            return _ball.transform.position.x;
        }

        return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
}