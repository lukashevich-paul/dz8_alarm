using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    public readonly string Horizontal = "Horizontal";

    [SerializeField] private float _speed = 3f;

    private void Update()
    {
        float translation = Input.GetAxis(nameof(Horizontal));

        if (translation != 0)
        {
            transform.Translate(Vector2.right * translation * _speed * Time.deltaTime);

            Reflect(translation);
        }
    }

    private void Reflect(float translation)
    {
        Vector3 scale = transform.localScale;

        if (translation < 0 && scale.x >= 0)
        {
            scale.x = -scale.x; ;
        }
        else if (translation > 0 && scale.x < 0)
        {
            scale.x = -scale.x; ;
        }

        transform.localScale = scale;
    }
}
