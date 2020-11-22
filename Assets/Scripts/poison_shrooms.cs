using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison_shrooms : MonoBehaviour
{

    // vars
    public int damage = -1;

    //Private Methods

    private void damage_player(RubyController player, int amount)
    {
       player.ChangeHealth(amount);
       Debug.Log("Hit ", player);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        int change = damage;

        if ( other.GetComponent<RubyController>() )
        {
            damage_player(other.GetComponent<RubyController>(), change);
            Destroy(gameObject);
        }
    }
}
