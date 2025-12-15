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
        public Stage3TextManager textMan;
        public GameObject rock;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Rock"))
            {
                if (!runOnce)
                {
                    textMan.positionChanged = true;
                    textMan.arrayPos = 15;
                    lavaRock.SetBool("cool", true);
                
                    smoke.Stop();
                    StartCoroutine(DelayCollectionofRock());
                }
            
            }
        }

        public IEnumerator DelayCollectionofRock()
        {
            yield return new WaitForSeconds(5F);
            rock.gameObject.SetActive(false);
            Debug.Log("THis Co Routing For Deleting ROck Is Firing");
        }
    }
}
