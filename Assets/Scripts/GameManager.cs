using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int _score = 0;
    public TMP_Text scoreText;
    public GameObject gameStartUI;
    public GameObject paddle;

    private void Awake()
    {
        Instance = this;
    }
    public void GameStart()
    {
        gameStartUI.SetActive(false);
        scoreText.gameObject.SetActive(true);
        paddle.gameObject.SetActive(true);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void ScoreUp()
    {
        _score++;
        scoreText.text = _score.ToString();
    }
}
