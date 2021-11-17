using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector3 direction = new Vector2();
    private float speed = 2;
    private GameManager _gameManager;

    private void Start()
    {
        GameObject manager = GameObject.FindGameObjectWithTag(GameManager.MANAGER_TAG);
        _gameManager = manager.GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        transform.position += ((direction * speed) * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isCollideWithShield = collision.transform.CompareTag(GameManager.SHIELD_TAG);
        bool isCollideWithWall = collision.transform.CompareTag(GameManager.OBSTACLEWALL_TAG);
        bool isCollideWithCircle = collision.transform.CompareTag(GameManager.CIRCLE_TAG);

        if(isCollideWithShield || isCollideWithWall || isCollideWithCircle)
        {
            if(isCollideWithCircle)
            {
                _gameManager.DecreaseLives(1);
            }
            gameObject.SetActive(false);
        }
    }
}
