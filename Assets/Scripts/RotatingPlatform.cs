using System.Collections;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RotatePlatform()
    {
        while (true)
        {
            transform.Rotate(Vector3.forward, 90 * Time.deltaTime);
            yield return null;
        }
    }
}
