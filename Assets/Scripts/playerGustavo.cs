using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGustavo : BasePlayerController, IAimable, IMoveable, IAttackable
{
    
    public Vector2 Position
    {
        get
        {
            return _aimPosition;
        }

        set
        {
            _aimPosition = value;

            Debug.Log("Aim from " + this.name);
        }
    }

    protected override void Awake()
    {
        base.Awake();

        Debug.Log("Child Awake");
    }

    protected override void Start()
    {
        base.Start();

        Debug.Log("Child Start");
    }

    public void Move(Vector2 direction)
    {
        Vector3 Direction = new Vector3(direction.x, 0, direction.y);
        myRigidBody.velocity = Direction;



    }

    public void Attack(Vector2 position)
    {
        Debug.Log("Attack from " + this.name);
    }
}
