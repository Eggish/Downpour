using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PathPainter : MonoBehaviour
{
    [SerializeField] private LineRenderer LineRenderer = null;
    private int PathBounceCount;
    // Start is called before the first frame update
    void Start()
    {
        PathBounceCount = LineRenderer.positionCount;
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer.SetPosition(0, transform.position);
        Vector3 rayStartPos = transform.position;
        Vector3 rayDirection = transform.up;
        for (int i = 1; i < PathBounceCount; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayStartPos, rayDirection);
            if (hit)
            {
                LineRenderer.SetPosition(i, hit.point);
                rayStartPos = hit.point;
                rayDirection = Vector3.Reflect(rayDirection, hit.normal);
            }
            //else
            //{
            //    return;
            //}
        }
    }
}
