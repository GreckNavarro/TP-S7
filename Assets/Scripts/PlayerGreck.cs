using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGreck : BasePlayerController, IAimable, IMoveable, IAttackable
{
    Vector3 Movimiento;
    Vector2 positionmouse;
    [SerializeField] int distancestop;
    [SerializeField] int velocity;
    [SerializeField] GameObject rafaga;
    public Vector2 Position
    {
        get
        {
            return _aimPosition;
        }

        set
        {
            _aimPosition = value;

            //Debug.Log("Aim from " + this.name);
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

        Quaternion qy = Quaternion.Euler(0f, direction.x, 0f);
        Quaternion qx = Quaternion.Euler(-direction.y, 0f, 0f);

       
        transform.rotation *= qy * qx;


        //transform.Rotate(direction);
    }

    public void Attack(Vector2 position)
    {
        rafaga.gameObject.SetActive(true);

        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            positionmouse = new Vector2(hit.point.x, hit.point.z);
            
        }

       
        OnMovement();
    }

    private void Update()
    {
        ValidateMovement();
    }
    private void OnMovement()
    {

            Vector3 direccionMouse = new Vector3(positionmouse.x, 0.5f, positionmouse.y);
            Movimiento = direccionMouse - transform.position;
            myRigidBody.velocity = new Vector3(Movimiento.x * velocity, myRigidBody.velocity.y, Movimiento.z * velocity);
    }

    private void ValidateMovement()
    {

        Vector2 probeMagnitude = new Vector2(transform.position.x, transform.position.z);
        Debug.Log((probeMagnitude - positionmouse).magnitude);


        if( (probeMagnitude - positionmouse).magnitude < distancestop)
        {
            myRigidBody.velocity = Vector3.zero;
            rafaga.gameObject.SetActive(false);
        }
    }
}
