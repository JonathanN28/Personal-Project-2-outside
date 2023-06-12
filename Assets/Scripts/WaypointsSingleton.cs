using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public sealed class WaypointsSingleton
{
    private static WaypointsSingleton instance;

    private List<GameObject> idleWaypoints = new List<GameObject>();

    private List<GameObject> attackWaypoints = new List<GameObject>();
    // Start is called before the first frame update
    public List<GameObject> IdleWaypoints
    {
        get
        {
            return idleWaypoints;
        }
    }

    public List<GameObject> AttackWaypoints
    {
        get
        {
            return attackWaypoints;
        }
    }

    public static WaypointsSingleton Singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new WaypointsSingleton();
                instance.idleWaypoints.AddRange(GameObject.FindGameObjectsWithTag("idleWaypoint"));
                instance.attackWaypoints.AddRange(GameObject.FindGameObjectsWithTag("attackWaypoint"));
            }

            return instance;
        }
    }
}
