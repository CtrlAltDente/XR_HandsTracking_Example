using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XRHandsExample.Interfaces;

namespace XRHandsExample.Spells
{
    public abstract class SpellObject : MonoBehaviour
    {
        public UnityEvent<IAlive> OnAliveTargetGetted;

        public void ActivateSpellObject(Transform hand, UnityAction<IAlive> spellAction)
        {
            OnAliveTargetGetted.AddListener(spellAction);
            StartCoroutine(SpellLogic(hand));
        }

        protected abstract IEnumerator SpellLogic(Transform hand);
    }
}