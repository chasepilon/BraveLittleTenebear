using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class DefendObject : MonoBehaviour
    {
        static protected DefendObject s_DefendObjectInstance;
        static public DefendObject DefendObjectInstance { get { return s_DefendObjectInstance; } }

        public Damageable damageable;
        private void Awake()
        {
            s_DefendObjectInstance = this;
        }

        public void OnHurt(Damager damager, Damageable damageable)
        {
            //if the player don't have control, we shouldn't be able to be hurt as this wouldn't be fair
            if (!PlayerInput.Instance.HaveControl)
                return;

            damageable.EnableInvulnerability();

            //if the health is < 0, mean die callback will take care of respawn
            if (damager.forceRespawn && damageable.CurrentHealth > 0)
            {
                GameController.isGameOver = true;
            }
        }

        public void OnDie()
        {
            GameController.isGameOver = true;
            //PlayerCharacter.PlayerInstance.OnDie();
        }

        public void Respawn(bool resetHealth, bool useCheckpoint)
        {
            if (resetHealth)
                damageable.SetHealth(damageable.startingHealth);
        }
    }
}
