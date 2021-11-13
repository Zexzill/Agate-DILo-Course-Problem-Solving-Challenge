using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed = 10;
    private Vector2 movement;
    private float h;
    private float v;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        //init movement
        Move(Vector2.right.x, Vector2.up.y);
    }

    private void Update()
    {
        //cek kecepatan bola
        Debug.Log($"speed: {_rigidbody2D.velocity.magnitude}");
    }

    private void FixedUpdate()
    {
        if(Input.anyKeyDown)
        {
            TrackInputMovement();

            Move(h, v);
        }
    }

    private void TrackInputMovement()
    {
        h = Input.GetAxisRaw("Horizontal");

        v = Input.GetAxisRaw("Vertical");

        if(h != 0 || v != 0)
        {
            ResetVelocity();
        }
    }

    private void ResetVelocity()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void Move(float horizontal, float vertical)
    {
        //set vector agar sesuai dengan input axis
        movement.Set(horizontal, vertical);

        //movement.normalized agar kecepatan stabil
        movement = movement.normalized * speed;

        _rigidbody2D.AddForce(movement);

        //reset horizontal dan vertical agar bisa terdeteksi apabila user menekan tombol axis nantinya
        h = 0;
        v = 0;
    }
}
