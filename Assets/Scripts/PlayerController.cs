using System;
using UnityEngine;

public class PlayerController : MoveController
{
    [SerializeField] private float _speed;
    private PlayerPositionSaver _playerPositionSaver;

    private void Awake()
    {
        _playerPositionSaver = new PlayerPositionSaver(transform);
    }

    private void Start()
    {
        _playerPositionSaver.LoadPlayerData();
    }
    
    private void Update()
    {
        _playerPositionSaver.SavePlayerData();
    }

    public override void Move(Vector2 inputs)
    {
        Vector3 movement = new Vector3(inputs.y, 0.0f, inputs.x);
        transform.position += movement * _speed * Time.deltaTime;
    }
}