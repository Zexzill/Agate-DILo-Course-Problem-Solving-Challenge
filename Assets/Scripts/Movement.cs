using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float Speed = 10;
    private float _firstVelocity = 0;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        MoveToMousePosition();
        _firstVelocity = _rigidbody2D.velocity.magnitude;
    }

    private void FixedUpdate()
    {
        MoveToMousePosition();
    }

    private void MoveToMousePosition()
    {
        //posisi mouse berdasarkan world position
        Vector2 inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentPosition = transform.position;

        //untuk menentukan arah objek ke target
        Vector2 direction = inputPosition - currentPosition;
        
        //menambahkan force sesuai direction sebelumnya
        _rigidbody2D.AddForce(direction.normalized * Speed);

        //mengecek velocity/speed rigidbody, apabila melebihi velocity pertama saat dijalankan maka velocity akan di reset menjadi velocity pertama saat dijalankan
        LimitRigidbodySpeed();
    }

    private void LimitRigidbodySpeed()
    {
        if(_rigidbody2D.velocity.magnitude > _firstVelocity)
        {
            //batasi kecepatan lingkaran saat awal bergerak
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * _firstVelocity;
        }
    }
}
