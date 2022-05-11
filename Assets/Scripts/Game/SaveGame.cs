using UnityEngine;

public class SaveGame : MonoBehaviour
{
    [SerializeField] private Game _game;

    private int _maxScore;

    public void TrySaveMaxScore()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
            _maxScore = PlayerPrefs.GetInt("MaxScore");

        if (_game.Score > _maxScore)
        {
            _maxScore = _game.Score;
            PlayerPrefs.SetInt("MaxScore", _maxScore);
        }
    }
}
