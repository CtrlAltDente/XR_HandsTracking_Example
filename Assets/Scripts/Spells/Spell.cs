using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRHandsExample.Interfaces;

namespace XRHandsExample.Spells
{
    public abstract class Spell : ScriptableObject
    {
        public Vector3 PositionOffset;
        public Quaternion RotationOffset;
        public SpellObject SpellObjectPrefab;

        public abstract void ActivateSpell(Transform hand);
        public abstract void StopSpell();
        public abstract void ApplySpellToTarget(IAlive aliveTarget);

    }
}