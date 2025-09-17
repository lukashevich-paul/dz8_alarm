using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    public void Move(float translation)
    {
        transform.Translate(Vector2.right * translation * _speed * Time.deltaTime);
    }
}
