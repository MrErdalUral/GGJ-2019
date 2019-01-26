using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        float offset = -2;
        transform.localScale = (1 - 0.1f * (transform.position.y-offset)) * Vector3.one;
    }
}
