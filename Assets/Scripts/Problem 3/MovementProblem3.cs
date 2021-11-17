using UnityEngine;

public class MovementProblem3 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float speed = 10;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _rigidbody2D.AddForce((Vector2.up + Vector2.right).normalized * speed);
    }

    private void Update()
    {
        Debug.Log($"speed: {_rigidbody2D.velocity.magnitude}");
    }
}
