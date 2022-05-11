using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DiePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _maxScore;
    [SerializeField] private Game _game;
    [SerializeField] private SaveGame _saveGame;
    private void OnEnable()
    {
        
        if (_game.Score > PlayerPrefs.GetInt("MaxScore"))
            _maxScore.text = "!!!New Record!!!\n";
        _maxScore.text += "Score :" + _game.Score;
        _saveGame.TrySaveMaxScore();
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);

    }

    public void Menu()
    {
        _saveGame.TrySaveMaxScore();
        SceneManager.LoadScene(0);
    }


}
