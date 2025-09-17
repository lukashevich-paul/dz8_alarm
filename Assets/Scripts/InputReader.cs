using UnityEngine;

public class InputReader : MonoBehaviour
{
    public readonly string Horizontal = "Horizontal";

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);
    }
}
