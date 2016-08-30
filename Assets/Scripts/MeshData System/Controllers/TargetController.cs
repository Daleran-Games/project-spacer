using UnityEngine;
using System.Collections;

public class TargetController : Controller {

    public GameObject target;

    void Update()
    {
        if (target == null)
            target = FindObjectOfType<PlayerController>().gameObject;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            directionVector = (Vector2)(target.transform.position - transform.position);
            movementVector = Vector2.zero;
        }
            
    }


}
