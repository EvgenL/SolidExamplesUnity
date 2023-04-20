using UnityEngine;

public class CarController : MoveController
{
    [SerializeField] private float _acceleration = 5f;
    [SerializeField] private float _maxSpeed = 50f;
    [SerializeField] private float _turnSpeed = 100f;

    private Rigidbody _rigidbody;
    private PlayerPositionSaver _playerPositionSaver;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
        float horizontal = inputs.y;
        float vertical = inputs.x;

        // расчет поворота машины
        float turn = horizontal * _turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        _rigidbody.MoveRotation(_rigidbody.rotation * turnRotation);

        // расчет ускорения и боковой силы
        Vector3 forwardForce = transform.forward * (vertical * _acceleration);
        Vector3 sidewaysForce = transform.right 
                                * (horizontal * _turnSpeed * Time.deltaTime * _rigidbody.velocity.magnitude);
        _rigidbody.AddForce(forwardForce + sidewaysForce, ForceMode.Acceleration);

        // ограничение максимальной скорости
        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
    }
}