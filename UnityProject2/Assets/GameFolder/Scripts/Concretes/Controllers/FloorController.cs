using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject2.Controllers
{
public class FloorController : MonoBehaviour
{
    [Range(0.5f,2f)]
    [SerializeField] float _moveSpeed = 1f;
    Material _material;

    private void Awake() 
    {
        _material = GetComponentInChildren<MeshRenderer>().material; // Floor1 elementinin daxilindeki Planede Mesh Rendererin icerisindeki materiali secirik
    }
    private void Update() {
        _material.mainTextureOffset += Vector2.up * Time.deltaTime * _moveSpeed; // Materialin Offset atributunun Y oxu menfiye dogru azalmalidir
    }
}
}
