using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRHandsExample.Interfaces;

namespace XRHandsExample.Spells
{
    public class LinearSpellObject : SpellObject
    {
        [SerializeField]
        private Transform _spellEndObject;

        [SerializeField]
        private ParticleSystem _particleSystem;

        protected override IEnumerator SpellLogic(Transform hand)
        {
            transform.parent = hand;

            _particleSystem.Play();

            while (isActiveAndEnabled)
            {
                yield return new WaitForSeconds(0.1f);

                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 15))
                {
                    if (hitInfo.collider.GetComponent<IAlive>() != null)
                    {
                        OnAliveTargetGetted?.Invoke(hitInfo.collider.GetComponent<IAlive>());
                    }

                    _spellEndObject.position = hitInfo.collider.transform.position;
                }
            }
        }
    }
}