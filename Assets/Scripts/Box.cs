using UnityEngine;

public class Box : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        GameObject targetObj = GameObject.FindGameObjectWithTag(GameManager.MANAGER_TAG);
        _gameManager = targetObj.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(GameManager.CIRCLE_TAG))
        {
            _gameManager.IncreaseScore(1);
            gameObject.SetActive(false);
        }
    }
}
