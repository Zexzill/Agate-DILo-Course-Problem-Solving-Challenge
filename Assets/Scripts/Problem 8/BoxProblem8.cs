using UnityEngine;

public class BoxProblem8 : MonoBehaviour
{
    private string _circleTag = "circle";
    private string _gameManagerTag = "manager";
    private GameManagerProblem8 _gameManager;

    private void Start()
    {
        GameObject targetObj = GameObject.FindGameObjectWithTag(_gameManagerTag);
        _gameManager = targetObj.GetComponent<GameManagerProblem8>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(_circleTag))
        {
            _gameManager.IncreaseScore(1);
            gameObject.SetActive(false);
        }
    }
}
