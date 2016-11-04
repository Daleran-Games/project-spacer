using UnityEngine;

namespace ProjectSpacer
{

    public class zGrid : MonoBehaviour
    {

        public string GridName;
        Rigidbody2D rb;

        //public Part[] parts;
        public ControlSystem controlSystem;

        private float nextCollision = 0.0f;

        // Use this for initialization
        void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            rb = GetComponent<Rigidbody2D>();
            //parts = GetComponentsInChildren<Part> ();


            //controlSystem = GetComponent<ControlSystem> ();
            //controlSystem.Initialize ();


            //InitializeParts ();
            //rb.mass = CalculateMass ();

            //controlSystem.Initialize ();

        }
        /*
        void InitializeParts () {
            foreach (Part p in parts) {
                p.Initialize ();
            }
        }


        private float CalculateMass () {
            float mass = 0.0f;
            foreach (Part p in parts) {
                mass += p.mass;
            }
            return mass;
        }
        */
        public virtual void OnCollisionEnter2D(Collision2D collision)
        {

            /*
            GameObject incomingObject = collision.contacts[0].collider.gameObject;
            GameObject partHit = collision.contacts[0].otherCollider.gameObject;

            if (partHit.GetComponent<DamageModule>() != null)
            {
                if (incomingObject.transform.root.GetComponent<zGrid>() != null)
                {
                    if (Time.time > nextCollision)
                    {
                        nextCollision = Time.time + GV.collisionRate;
                        Vector2 vDiff = rb.velocity * rb.mass - incomingObject.transform.root.GetComponent<Rigidbody2D>().velocity * incomingObject.transform.root.GetComponent<Rigidbody2D>().mass;
                        int dmg = (int)((Mathf.Abs(vDiff.x) + Mathf.Abs(vDiff.y)) * GV.collisionDamageModifer);
                        Debug.Log("Collision between " + collision.gameObject.name + " and " + gameObject.name + " for " + dmg + " dmg.");
                        partHit.GetComponent<DamageModule>().Damage(dmg);
                    }
                }
                else if (collision.gameObject.tag == "Projectile")
                {
                    Debug.Log("Dealing " + collision.gameObject.GetComponent<Projectile>().damage + " dmg to " + gameObject.name);
                    partHit.GetComponent<DamageModule>().Damage(incomingObject.GetComponent<Projectile>().damage);
                }
            }
            */

        }




    }
}