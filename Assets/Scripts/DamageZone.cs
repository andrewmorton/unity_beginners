using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DamageZone : MonoBehaviour
{
    public int damage = -1;
    private void OnTriggerStay2D(Collider2D other)
    {
        var trigger = other.GetComponent<RubyController>();
        if (trigger != null && trigger.health != 0)
        {
            trigger.ChangeHealth(damage);
            Debug.Log($"Damaged {trigger.name}");
        }
    }
}
