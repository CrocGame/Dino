using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text _maxScore;
    private void Start()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
            _maxScore.text = "Max Score: " + PlayerPrefs.GetInt("MaxScore");
        else
            _maxScore.text = "Max Score: 0";
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
