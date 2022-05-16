using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float boundingRadius = 20f;
    [SerializeField] float margin = 1f;

    // Update is called once per frame
    void Update()
    {
        float distFromOrigin = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.z, 2));
        if (distFromOrigin > boundingRadius + margin)
        {
            Destroy(gameObject);
        }
    }
}
