using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhyCheack : MonoBehaviour
{
    public bool _isGround = true;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = false;
        }
    }
}
