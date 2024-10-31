using System.Collections;
using UnityEngine;

public class ImageRocking : MonoBehaviour
{
    [SerializeField] private float _rockingAngle = 10f;
    [SerializeField] private float _rockingSpeed = 50f;
    [SerializeField] private float _rockingDuration = 1f;
    [SerializeField] private float _pauseDuration = 1f;

    private Vector3 _initialRotation;
    private bool _isRocking = true;
    private float _elapsedTime = 0f;
    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;

    void Start()
    {
        _waitForSeconds = new WaitForSeconds(_pauseDuration);
        _initialRotation = transform.eulerAngles;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        StartCoroutine(RockingCoroutine());
    }

    IEnumerator RockingCoroutine()
    {
        while (true)
        {
            transform.eulerAngles = _initialRotation;
            yield return _waitForSeconds;

            if (_isRocking)
            {
                _elapsedTime = 0f;

                while (_elapsedTime < _rockingDuration)
                {
                    float rocking = Mathf.Sin(_elapsedTime * _rockingSpeed) * _rockingAngle;
                    transform.eulerAngles = new Vector3(_initialRotation.x, _initialRotation.y, rocking);
                    _elapsedTime += Time.deltaTime;
                    yield return null;
                }
            }
        }
    }
}