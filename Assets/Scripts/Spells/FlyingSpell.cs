using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRHandsExample.Interfaces;

namespace XRHandsExample.Spells
{
    [CreateAssetMenu(fileName = "FlyingSpell_", menuName = "ScriptableObject/FlyingSpell", order = 0)]
    public class FlyingSpell : Spell
    {
        public int Damage;

        public override void ActivateSpell(Transform hand)
        {
            SpellObject spellObject = Instantiate(SpellObjectPrefab, hand.position + PositionOffset, hand.rotation * RotationOffset);
            spellObject.ActivateSpellObject(hand, ApplySpellToTarget);
        }

        public override void ApplySpellToTarget(IAlive aliveTarget)
        {
            aliveTarget.HealthSystem.ReceiveDamage(Damage);
        }

        public override void StopSpell()
        {

        }
    }
}