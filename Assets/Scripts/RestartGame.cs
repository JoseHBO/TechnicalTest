using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField]
    private Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(RestartGameButton);
    }

    private void RestartGameButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
