using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Viewer))]
public class Player : MonoBehaviour
{
    public readonly string Horizontal = "Horizontal";

    [SerializeField] private InputReader _inputReader;
    private Mover _mover;
    private Viewer _viewer;

    private void Start()
    {
        _mover = GetComponent<Mover>();
        _viewer = GetComponent<Viewer>();
    }

    private void Update()
    {
        float translation = _inputReader.Direction;

        if (translation != 0)
        {
            _mover.Move(translation);
            _viewer.Reflect(translation);
        }
    }
}
