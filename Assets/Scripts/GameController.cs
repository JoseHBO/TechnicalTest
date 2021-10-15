using UnityEngine;
using UnityEngine.UI;

// Enum with game states.
public enum GameState {activeGame, endGame}

public class GameController : MonoBehaviour
{
    #region Private variables/fields

    [SerializeField]
    private GameObject endPanel;

    [SerializeField]
    private GameObject timeEnded;

    [SerializeField]
    private GameObject restartGame;

    [SerializeField]
    private Text totalCookies;    

    private CookiesManager cookies;

    private int highScore;       

    #endregion

    [HideInInspector]
    public static GameState state;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        state = GameState.activeGame;

        cookies = GameObject.FindWithTag("CookiesManager").GetComponent<CookiesManager>();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.endGame)
        {
            Time.timeScale = 0;

            endPanel.SetActive(true);

            restartGame.SetActive(true);
        }
        else if (StopwatchManager.timeOver)
        {
            totalCookies.text = "Your score is: " + cookies.Getcookies().ToString();

            if (cookies.Getcookies() > highScore)
            {
                PlayerPrefs.SetInt("HighScore", cookies.Getcookies());
            }

            Time.timeScale = 0;

            timeEnded.SetActive(true);

            restartGame.SetActive(true);

            StopwatchManager.timeOver = false;
        }
    }
}

