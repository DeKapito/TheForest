using UnityEngine;
using System.Collections;
public class SceneController : MonoBehaviour
{
    public GameObject menu;

    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;

    private bool isPaused;

    public void ResumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void PauseGame()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ExitGame()
    {
        Debug.Log("Exited");
        Application.Quit();
    }

    void Start()
    {
        PauseGame();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            } else {
                PauseGame();
            }
        }

        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(93, 23, 87);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}