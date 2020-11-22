using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Create var for rigidbody
    private Rigidbody2D _body;
    
    //#### Public Properties ####//
    public int maxHealth = 2;

    public int CurrentHealth => _currentLife;
    
    // Set max distance that I want the patrol to go
    public int xPatrolUnits = 5;
    public int yPatrolUnits = 0;
    
    // Max speed
    public float charSpeed = 5.0f;
    
    //#### END ####//

    //#### _Properties ####//
    private int _currentLife;
    private Vector2 _startingPosition;
    private Vector2 _finalPosition;
    private bool _patBack;
    
    //#### END ####//

    private Vector2 ReturnFinalVector(Vector2 currentPosition, float maxX, float maxY)
    {
        var vector = new Vector2((currentPosition.x + maxX), (currentPosition.y + maxY));
        return vector;
    }
    
    //helper function
    // takes float, adds speed, delta, and multiplies by Time.deltaTime;
    // returns float
    private float MoveDelta(float start, float speed, int moveDelta)
    {
        var results = start + speed * moveDelta * Time.deltaTime;
        return results;
    }


    private Vector2 shiftVectorX(Vector2 body, int delta)
    {
        var newX = MoveDelta(body.x, charSpeed, delta);
        var results = new Vector2(newX, body.y);
        return results;
    }
    
    private Vector2 shiftVectorY(Vector2 body, int delta)
    {
        var newY = MoveDelta(body.y, charSpeed, delta);
        var results = new Vector2(body.x, newY);
        return results;
    }

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _currentLife = maxHealth;
        _startingPosition = _body.position;
        _finalPosition = ReturnFinalVector(_startingPosition, xPatrolUnits, yPatrolUnits);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var curPos = _body.position;
        if (curPos.x <= _finalPosition.x)
        {
          _body.MovePosition(shiftVectorX(curPos, 1));
          return;
        }

        if (curPos.x >= _startingPosition.x)
        {
            _body.MovePosition((shiftVectorX(curPos, -1)));
            return;
        }
        // Once >= FinalPos, decrement until <= StartingPos
    }
}
