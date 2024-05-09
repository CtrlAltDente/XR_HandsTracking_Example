using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace XRHandsExample.Base
{
    public class HealthSystem : MonoBehaviour
    {
        public UnityEvent OnDeath;

        public int MaxHealth;
        public int CurrentHealth;

        public void ReceiveDamage(int damage)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);

            if(CurrentHealth <= 0)
            {
                OnDeath?.Invoke();
            }
        }

        public void ReceiveHealing(int healing)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + healing, 0, MaxHealth);
        }
    }
}