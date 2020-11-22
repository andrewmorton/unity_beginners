using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Setting Health for main char controller
    public int maxHealth = 5;
    public string health_msg = "Collected Health Pickup";
    public float speed = 4.0f;

    public int health => currentHealth;
    internal int currentHealth;

    Rigidbody2D _rigidbody2D;
    private float _inputHor;
    private float _inputVert;
    
    // Iframes timer
    public float iFrames = 3.0f;
    private float _iFramesTimer;
    private bool _isInvincible;


    private static float return_input(string type)
    {
        return Input.GetAxis(type);
    }

    // Behavior Methods

    private void CheckTimer()
    {
        //check current timer value
        // if timer != 0, decrement
        if (_iFramesTimer <= 0)
        {
            _isInvincible = false;
        }
        else
        {
            _iFramesTimer -= Time.deltaTime;
            Debug.Log($"Timer: {_iFramesTimer}");
        }

    }

    public void ChangeHealth(int delta)
    {
        if (_isInvincible) return;
        // adjust ruby's health
        currentHealth = Mathf.Clamp(currentHealth + delta, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        // If ruby gained health, no iFrames
        if (delta > 0) return;
        // else
        _isInvincible = true;
        _iFramesTimer = iFrames;
    }



    // Trigger enters
    private Collider2D OnTriggerEnter2D(Collider2D other) {
        //define healthobject
        if ( other.isTrigger )
        {
            Debug.Log("Tag: " + other.tag);
        }
        return other;
    }

    private void collect_health_msg(ref string msg)
    {
        Debug.Log(msg);
    }



    /* Frame Functions */
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        _inputHor = return_input("Horizontal");
        _inputVert = return_input("Vertical");
        
        if (_isInvincible)
        {
            CheckTimer();
        }
    }


    void FixedUpdate() {
        Vector2 position = _rigidbody2D.position;
        position.x = position.x + speed * _inputHor * Time.deltaTime;
        position.y = position.y + speed * _inputVert * Time.deltaTime;

        _rigidbody2D.MovePosition(position);
    }

}
