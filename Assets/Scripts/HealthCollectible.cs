using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D trigger) {
        RubyController control = trigger.GetComponent<RubyController>();

        // If Ruby enters, increase health
        if ((control != null) && ( control.currentHealth < control.maxHealth ))
        {
            control.ChangeHealth(1);
            Destroy(gameObject);
        }

        Debug.Log("Object that entered trigger: " + trigger);
    }
}
