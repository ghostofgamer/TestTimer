using TMPro;
using UnityEngine;

public class TimeViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.TimeChanged += ChangeTime;
        _timer.TimeOver += StopTime;
    }

    private void OnDisable()
    {
        _timer.TimeChanged -= ChangeTime;
        _timer.TimeOver -= StopTime;
    }

    private void ChangeTime(int hours, int minutes, int seconds)
    {
        _timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    private void StopTime()
    {
        _timerText.text = "00:00:00";
    }
}