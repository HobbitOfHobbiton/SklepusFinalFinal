using UnityEngine;
using System.Collections;
 
[RequireComponent (typeof(MatrixBlender))]
public class PerspectiveSwitcher : MonoBehaviour
{
    private Matrix4x4   _ortho, _perspective;
    public float fov = 60f, 
        near = .3f,
        far = 1000f,
        orthographicSize = 50f;
    private float _aspect;
    private MatrixBlender _blender;
    private bool _orthoOn;
 
    void Start()
    {
        _aspect = (float) Screen.width / (float) Screen.height;
        _ortho = Matrix4x4.Ortho(-orthographicSize * _aspect, orthographicSize * _aspect, -orthographicSize, orthographicSize, near, far);
        _perspective = Matrix4x4.Perspective(fov, _aspect, near, far);
        GetComponent<Camera>().projectionMatrix = _ortho;
        _orthoOn = true;
        _blender = (MatrixBlender) GetComponent(typeof(MatrixBlender));
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _orthoOn = !_orthoOn;
            if (_orthoOn)
                _blender.BlendToMatrix(_ortho, 1f);
            else
                _blender.BlendToMatrix(_perspective, 1f);
        }
    }
}