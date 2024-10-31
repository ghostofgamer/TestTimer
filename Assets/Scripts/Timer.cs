using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _totalTime = 1800f;
    private int _hours;
    private int _minutes;
    private int _seconds;
    private int _secondsInHour = 3600;
    private int _minutsInHour = 60;
    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    public event Action<int, int, int> TimeChanged;

    public event Action TimeOver;

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (_totalTime > 0)
        {
            _hours = Mathf.FloorToInt(_totalTime / _secondsInHour);
            _minutes = Mathf.FloorToInt((_totalTime % _secondsInHour) / _minutsInHour);
            _seconds = Mathf.FloorToInt(_totalTime % _minutsInHour);
            TimeChanged?.Invoke(_hours, _minutes, _seconds);
            yield return _waitForSeconds;
            _totalTime -= 1f;
        }

        TimeOver?.Invoke();
    }
}