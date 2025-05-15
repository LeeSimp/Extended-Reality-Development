using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    public bool IsStanding => Vector3.Angle(transform.up, Vector3.up) < 10f;

    void Update()
    {
        // Optional: Visual debugging
        Debug.DrawRay(transform.position, transform.up * 2, Color.green);
    }
}
