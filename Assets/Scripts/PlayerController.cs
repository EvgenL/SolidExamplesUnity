using UnityEngine;

public class PlayerController : MonoBehaviour
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
        Move();
        _playerPositionSaver.SavePlayerData();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.position += movement * _speed * Time.deltaTime;
    }
}