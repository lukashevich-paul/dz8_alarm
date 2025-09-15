using UnityEngine;

public class Alarm : MonoBehaviour
{
    public const float MinVolume = 0f;
    public const float MaxVolume = 1f;

    [SerializeField] private float _fadeTime = 5f;
    [SerializeField] private EventTrigger _eventTrigger;

    private AudioSource _audioSource;
    private float _volume = 0;
    private bool _isActive = false;

    private void OnEnable()
    {
        _eventTrigger.Enter += ToggleActive;
        _eventTrigger.Exit += ToggleActive;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _volume;
    }

    private void Update()
    {
        ChangeVolume();

        if (_audioSource.isPlaying == true)
        {
            _audioSource.volume = _volume;

            if (_audioSource.isPlaying == true && _volume <= MinVolume)
                _audioSource.Stop();
        }
        else
        {
            if (_volume > MinVolume)
                _audioSource.Play();
        }
    }

    private void OnDisable()
    {
        _eventTrigger.Enter -= ToggleActive;
        _eventTrigger.Exit -= ToggleActive;
    }

    private void ChangeVolume()
    {
        if (_isActive == true && _volume < MaxVolume)
        {
            _volume = Mathf.MoveTowards(_volume, MaxVolume, MaxVolume / _fadeTime * Time.deltaTime);
        }
        else if (_isActive == false && _volume > MinVolume)
        {
            _volume = Mathf.MoveTowards(_volume, MinVolume, MaxVolume / _fadeTime * Time.deltaTime);
        }
    }

    private void ToggleActive()
    {
        _isActive = !_isActive;
    }
}
