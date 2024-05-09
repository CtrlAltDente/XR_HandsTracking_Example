using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    public bool IsGrabbed { get; private set; }

    public void Grab(Transform transform)
    {
        this.transform.parent = transform;
        transform.localPosition = Vector3.zero;
        _rigidbody.isKinematic = true;
        IsGrabbed = true;
    }

    public void Drop()
    {
        transform.parent = null;
        _rigidbody.isKinematic = false;
        IsGrabbed = false;
    }
}
