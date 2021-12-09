using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy  : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed;
    private Vector3 AuxScale;
    private int _currentwaypoint = 0;
    protected bool canMove = true;


    public void Patrol()
    {
        if(canMove)
        {
            Vector3 dir = waypoints[_currentwaypoint].position - transform.position;
            Vector3 actualdir = dir.normalized;
            transform.position += actualdir * speed * Time.deltaTime;

            if(dir.magnitude < 0.1f)
            {    
                _currentwaypoint++;
                if (_currentwaypoint > waypoints.Count - 1)
                    _currentwaypoint = 0;
                FlipScale();
            }
        }
    }

    private void FlipScale()
    {
        AuxScale = transform.localScale;
        AuxScale.x = -AuxScale.x;
        transform.localScale = AuxScale;
    }

    public abstract void TakeDamage();

    public Enemy SetPos (Vector3 newPos)
    {
        transform.position = newPos;
        return this;
    }

    public Enemy SetWaypoints (List<Transform> newWaypoints)
    {
        waypoints = newWaypoints;
        return this;
    }

    public Enemy SetSize(Vector3 newSize)
    {
        transform.localScale = newSize;
        return this;
    }

}