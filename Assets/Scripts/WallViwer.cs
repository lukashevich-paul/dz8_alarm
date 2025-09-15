using UnityEngine;

public class WallViwer : MonoBehaviour
{
    [SerializeField] private EventTrigger _eventTrigger;
    [SerializeField] private Transform[] _walls;

    private void OnEnable()
    {
        _eventTrigger.Enter += Hide;
        _eventTrigger.Exit += Show;
    }

    private void OnDisable()
    {
        _eventTrigger.Enter -= Hide;
        _eventTrigger.Exit -= Show;
    }

    private void Hide()
    {
        foreach (Transform wall in _walls)
        {
            wall.gameObject.SetActive(false);
        }
    }

    private void Show()
    {
        foreach (Transform wall in _walls)
        {
            wall.gameObject.SetActive(true);
        }
    }
}
