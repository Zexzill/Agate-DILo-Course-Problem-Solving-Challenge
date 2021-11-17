using UnityEngine;

public class BoxProblem9 : MonoBehaviour
{
    private GameManagerProblem9 _gameManager;

    private void Start()
    {
        GameObject targetObj = GameObject.FindGameObjectWithTag(GameManagerProblem9.MANAGER_TAG);
        _gameManager = targetObj.GetComponent<GameManagerProblem9>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(GameManagerProblem9.CIRCLE_TAG))
        {
            _gameManager.IncreaseScore(1);
            gameObject.SetActive(false);
        }
    }
}
