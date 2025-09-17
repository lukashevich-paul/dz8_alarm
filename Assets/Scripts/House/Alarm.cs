using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    public const float MinVolume = 0f;
    public const float MaxVolume = 1f;

    [SerializeField] private float _fadeTime = 5f;

    private float _volume = 0f;
    private AudioSource _audioSource;
    private Coroutine _coroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _volume;
    }

    public void TurnOn()
    {
        StartCoroutine(MaxVolume);
    }

    public void TurnOff()
    {
        StartCoroutine(MinVolume);
    }

    private void StartCoroutine(float target)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(FadeAlarm(target));
    }

    private IEnumerator FadeAlarm(float volumeTarget)
    {
        float delay = Time.deltaTime;
        WaitForSeconds wait = new WaitForSeconds(delay);

        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        while (volumeTarget != _volume)
        {
            _volume = Mathf.MoveTowards(_volume, volumeTarget, MaxVolume * delay / _fadeTime);
            _audioSource.volume = _volume;

            yield return wait;
        }

        if (_volume <= MinVolume)
            _audioSource.Stop();

        StopCoroutine(_coroutine);
        _coroutine = null;
    }
}
