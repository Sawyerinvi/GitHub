using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float _health, _score = 0f;
    private FallingObject _faller;
    [SerializeField] private Player player;
    [SerializeField] private Text _scoreUI, _healthUI;
    
    private void Start()
    {
        player.OnPlayerHit += GetStats;
        _health = player.PlayerHealth;
        _healthUI.text = _health.ToString();
        _scoreUI.text = _score.ToString();
        

    }

    private void GetStats(float health, FallingObject faller)
    {
        _health = health;
        _faller = faller;
        SetScoreData();
    }

    private void SetScoreData()
    {
        _score += _faller.Score;
        _scoreUI.text = _score.ToString();
        _healthUI.text = _health.ToString();
    }


}
