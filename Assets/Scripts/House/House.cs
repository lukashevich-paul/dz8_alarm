using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private ThiefDetector _detector;
    [SerializeField] private Alarm _alarm;
    [SerializeField] private Transform[] _walls;

    private void OnEnable()
    {
        _detector.Entered += OnEntered;
        _detector.Exited += OnExited;
    }

    private void OnDisable()
    {
        _detector.Entered -= OnEntered;
        _detector.Exited -= OnExited;
    }

    private void OnEntered()
    {
        _alarm.TurnOn();

        foreach (Transform wall in _walls)
        {
            wall.gameObject.SetActive(false);
        }
    }

    private void OnExited()
    {
        _alarm.TurnOff();

        foreach (Transform wall in _walls)
        {
            wall.gameObject.SetActive(true);
        }
    }
}
