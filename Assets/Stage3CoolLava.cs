using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.Geoquest
{
    public class Stage3CoolLava : MonoBehaviour
    {

        public Animator lavaRock;
        public bool runOnce;
        public ParticleSystem smoke;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Rock"))
            {
                if (!runOnce)
                {
                    lavaRock.SetBool("cool", true);
                    smoke.Stop();
                }
            
            }
        }
    }
}
