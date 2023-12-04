using UnityEngine;
using UnityEngine.InputSystem;

public class TekitoMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    private Transform _player = null;
    private Camera _look = null;

    private void Awake()
    {
        _player = transform;
        _look = Camera.main;
    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;

        if (Keyboard.current[Key.W].isPressed)
        {
            direction += Vector3.ProjectOnPlane(_look.transform.forward, Vector3.up);
        }
        if (Keyboard.current[Key.A].isPressed)
        {
            direction += Vector3.ProjectOnPlane(-_look.transform.right, Vector3.up);
        }
        if (Keyboard.current[Key.S].isPressed)
        {
            direction += Vector3.ProjectOnPlane(-_look.transform.forward, Vector3.up);
        }
        if (Keyboard.current[Key.D].isPressed)
        {
            direction += Vector3.ProjectOnPlane(_look.transform.right, Vector3.up);
        }

        if (direction != Vector3.zero)
        {
            direction = direction.normalized;
            _player.transform.rotation = Quaternion.LookRotation(direction);
            _player.transform.position += direction * _speed * Time.deltaTime;
        }
    }
}
