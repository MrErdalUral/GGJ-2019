using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<MeshRenderer>().sortingLayerName = "Background";
        Debug.Log(GetComponent<MeshRenderer>().sortingLayerName);
    }

}
