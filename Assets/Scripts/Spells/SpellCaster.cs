using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XRHandsExample.Spells
{
    public class SpellCaster : MonoBehaviour
    {
        [SerializeField]
        private Transform _handTransform;

        public void ActivateSpell(Spell spell)
        {
            spell.ActivateSpell(_handTransform);
        }

        public void StopSpell(Spell spell)
        {
            spell.StopSpell();
        }
    }
}