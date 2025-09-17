using UnityEngine;

public class Viewer : MonoBehaviour
{
    public void Reflect(float translation)
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
