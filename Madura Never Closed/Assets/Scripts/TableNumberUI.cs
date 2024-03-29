using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableNumberUI : MonoBehaviour
{
    [SerializeField] private Transform lookAt;
    [SerializeField] private Vector3 offset;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cam.WorldToScreenPoint(lookAt.position + offset);

        if (transform.position != pos)
        {
            transform.position = pos;
        }
    }
}
