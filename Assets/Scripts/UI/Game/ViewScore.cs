using UnityEngine;
using TMPro;

public class ViewScore : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private TMP_Text _textScore;
    void Update()
    {
        _textScore.text = "Score: "+(_game.Score).ToString();
    }
}
