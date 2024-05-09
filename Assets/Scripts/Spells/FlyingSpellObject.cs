using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRHandsExample.Interfaces;

namespace XRHandsExample.Spells
{
    public class FlyingSpellObject : SpellObject
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.GetComponent<IAlive>() != null)
            {
                OnAliveTargetGetted?.Invoke(collision.collider.GetComponent<IAlive>());
            }

            Destroy(gameObject);
        }

        protected override IEnumerator SpellLogic(Transform hand)
        {
            _rigidbody.AddForce(transform.forward * 25, ForceMode.Impulse);
            yield return new WaitForSeconds(10);
            Destroy(gameObject);
        }
    }
}