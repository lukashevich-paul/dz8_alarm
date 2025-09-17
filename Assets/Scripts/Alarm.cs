using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    public const float MinVolume = 0f;
    public const float MaxVolume = 1f;

    [SerializeField] private float _fadeTime = 5f;

    private AudioSource _audioSource;
    private float _volume = 0f;

    private Coroutine _coroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _volume;
    }

    private IEnumerator FadeAlarm(float volumeTarget)
    {
        float delay = Time.deltaTime;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (volumeTarget != _volume)
        {
            _volume = Mathf.MoveTowards(_volume, volumeTarget, MaxVolume * delay / _fadeTime);
            _audioSource.volume = _volume;
            SoundTumbler();

            yield return wait;
        }

        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private void SoundTumbler()
    {
        if (_audioSource.isPlaying == true && _volume <= MinVolume)
            _audioSource.Stop();
        else if (_audioSource.isPlaying == false && _volume > MinVolume)
            _audioSource.Play();
    }

    private void StartCoroutine(float target)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(FadeAlarm(target));
    }

    public void TurnOn()
    {
        StartCoroutine(MaxVolume);
    }

    public void TurnOff()
    {
        StartCoroutine(MinVolume);
    }
}
