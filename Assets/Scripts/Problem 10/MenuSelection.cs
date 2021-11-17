using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuSelection : MonoBehaviour
{
    public static bool canDestroy = true;
    private void Awake()
    {
        if(canDestroy)
        {
            DontDestroyOnLoad(gameObject);
            canDestroy = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Problem 10");
            Time.timeScale = 1;
        }
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
