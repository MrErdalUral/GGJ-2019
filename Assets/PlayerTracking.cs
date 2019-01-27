using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    public float mag = 0.1f;

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
            return;
        var dir = (player.transform.position - transform.position).normalized;
        transform.localPosition = mag * dir;
    }
}
