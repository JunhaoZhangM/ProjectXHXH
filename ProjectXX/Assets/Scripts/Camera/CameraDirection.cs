using System;
using UnityEngine;

public class CameraDirection : MonoBehaviour
{
    public Material material;
    public float n; //假渲染识别参数（请勿随便调）

    void Update()
    {
        //获取物体的世界位置
        Vector3 objectPosition = transform.position;

        //获取相机的位置
        Vector3 cameraPosition = Camera.main.transform.position;

        //假渲染！
        Vector3 d1 = objectPosition - cameraPosition;
        material.SetFloat("_angle", Math.Abs(transform.rotation.x) * n);
        transform.forward = new Vector3(d1.x, d1.y, d1.z);
    }
}