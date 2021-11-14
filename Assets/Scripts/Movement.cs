using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed = 10;
    private Vector2 movement;
    private float h;
    private float v;
    private float firstVelocity = 0;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        MoveToMousePosition();
        firstVelocity = _rigidbody2D.velocity.magnitude;
        //init movement
        //Move(Vector2.right.x, Vector2.up.y);
    }

    private void Update()
    {
        //cek kecepatan bola
        Debug.Log($"speed: {_rigidbody2D.velocity.magnitude}");
    }

    private void FixedUpdate()
    {
        MoveToMousePosition();
        //if(Input.anyKeyDown)
        //{
            //TrackInputMovement();

            //Move(h, v);
        //}
    }

    private void MoveToMousePosition()
    {
        //posisi mouse berdasarkan world position
        Vector2 inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentPosition = transform.position;

        //untuk menentukan arah objek ke target
        Vector2 direction = inputPosition - currentPosition;
        
        //menambahkan force sesuai direction sebelumnya
        _rigidbody2D.AddForce(direction.normalized * speed);

        //mengecek velocity/speed rigidbody, apabila melebihi velocity pertama saat dijalankan maka velocity akan di reset menjadi velocity pertama saat dijalankan
        LimitRigidbodySpeed();
    }

    private void LimitRigidbodySpeed()
    {
        if(_rigidbody2D.velocity.magnitude > firstVelocity)
        {
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * firstVelocity;
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
