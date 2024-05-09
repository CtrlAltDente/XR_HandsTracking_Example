using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRHandsExample.Interfaces;

namespace XRHandsExample.Spells
{
    [CreateAssetMenu(fileName = "LinearSpell_", menuName = "ScriptableObject/LinearSpell", order = 1)]
    public class LinearSpell : Spell
    {
        public int Damage;

        private SpellObject _spellObject;

        public override void ActivateSpell(Transform hand)
        {
            _spellObject = Instantiate(SpellObjectPrefab, hand.position + PositionOffset, hand.rotation * RotationOffset);
            _spellObject.ActivateSpellObject(hand, ApplySpellToTarget);
        }

        public override void StopSpell()
        {
            if (_spellObject != null)
            {
                Destroy(_spellObject.gameObject);            
            }

            _spellObject = null;
        }

        public override void ApplySpellToTarget(IAlive aliveTarget)
        {
            aliveTarget.HealthSystem.ReceiveDamage(Damage);
        }
    }
}
