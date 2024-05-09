using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Grabber : MonoBehaviour
{
    [SerializeField]
    private Collider _collider;

    private GrabbableObject _availableGrabbableObject;

    private void Awake()
    {
        if (_collider == null)
        {
            _collider = GetComponent<Collider>();
        }
    }

    public void GrabObject()
    {
        if (_availableGrabbableObject.IsGrabbed)
            return;
        
        _availableGrabbableObject.Grab(transform);
    }

    public void DropObject()
    {
        if (!_availableGrabbableObject.IsGrabbed)
            return;

        _availableGrabbableObject.Drop();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("New object");
        if (_availableGrabbableObject != null)
            if (_availableGrabbableObject.IsGrabbed)
                return;
        
        GrabbableObject grabbableObject = other.gameObject.GetComponent<GrabbableObject>();

        if (grabbableObject != null)
        {
            _availableGrabbableObject = grabbableObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GrabbableObject grabbableObject = other.gameObject.GetComponent<GrabbableObject>();

        if (grabbableObject != null && _availableGrabbableObject == grabbableObject)
        {
            _availableGrabbableObject = null;
        }
    }
}
