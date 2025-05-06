using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    float offsetX;

    void Start()
    {
        if (target == null)
            return;
        //offsetX = transform.position.x - target.position.x;
        offsetX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}
