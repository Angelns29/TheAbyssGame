using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFixedSize : MonoBehaviour
{
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        Debug.Log("Pixel width :" + _camera.pixelWidth + " Pixel height : " + _camera.pixelHeight);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
