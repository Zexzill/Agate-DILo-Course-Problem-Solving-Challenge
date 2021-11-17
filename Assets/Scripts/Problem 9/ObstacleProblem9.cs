using UnityEngine;

public class ObstacleProblem9 : MonoBehaviour
{
    public Vector3 direction = new Vector2();
    private float speed = 2;
    private GameManagerProblem9 _gameManager;

    private void Start()
    {
        GameObject manager = GameObject.FindGameObjectWithTag(GameManagerProblem9.MANAGER_TAG);
        _gameManager = manager.GetComponent<GameManagerProblem9>();
    }

    private void FixedUpdate()
    {
        transform.position += ((direction * speed) * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isCollideWithShield = collision.transform.CompareTag(GameManagerProblem9.SHIELD_TAG);
        bool isCollideWithWall = collision.transform.CompareTag(GameManagerProblem9.OBSTACLEWALL_TAG);
        bool isCollideWithCircle = collision.transform.CompareTag(GameManagerProblem9.CIRCLE_TAG);

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
