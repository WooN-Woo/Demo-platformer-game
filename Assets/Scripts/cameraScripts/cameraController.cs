using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField]
    Transform targetTransform;

    [SerializeField]
    float minY, maxY;

    [SerializeField]

    Transform altZemin, ortaZemin;

    Vector2 lastPos;

    private void Start()
    {
        
    }

    private void Update()
    {
        cameraFnc();

        bGroundFnc();
    }


    void cameraFnc()
    {
        transform.position = new Vector3(targetTransform.position.x,
            Mathf.Clamp(targetTransform.position.y, minY, maxY),transform.position.z);
    }

    void bGroundFnc()
    {
        Vector2 aradakiMiktar = new Vector2( transform.position.x - lastPos.x, transform.position.y - lastPos.y );

        altZemin.position += new Vector3(aradakiMiktar.x, aradakiMiktar.y, 0f);
        ortaZemin.position += new Vector3(aradakiMiktar.x, aradakiMiktar.y, 0f)*0.5f;

        lastPos = transform.position;
    }
        



}
