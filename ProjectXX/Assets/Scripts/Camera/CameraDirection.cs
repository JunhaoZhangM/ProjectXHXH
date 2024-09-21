using System;
using UnityEngine;

public class CameraDirection : MonoBehaviour
{
    public Material material;
    public float n; //����Ⱦʶ�����������������

    void Update()
    {
        //��ȡ���������λ��
        Vector3 objectPosition = transform.position;

        //��ȡ�����λ��
        Vector3 cameraPosition = Camera.main.transform.position;

        //����Ⱦ��
        Vector3 d1 = objectPosition - cameraPosition;
        material.SetFloat("_angle", Math.Abs(transform.rotation.x) * n);
        transform.forward = new Vector3(d1.x, d1.y, d1.z);
    }
}