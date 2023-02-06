using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoaiMove : MonoBehaviour
{
    [SerializeField]
    private WaypointPath _waypointpath;

    [SerializeField]
    private float _speed;

    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;


    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveMoai();
    }
    private void OnTriggerEnter(Collider other )
    {
        moveMoai();
    }
    private void moveMoai()
    {
        _elapsedTime += Time.deltaTime;

        float elapsedPercentage = _elapsedTime / _timeToWaypoint;
        //Hace smooth el principio y el final para facilitar que el jugador pueda subirse
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);

        transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elapsedPercentage);

        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }
    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointpath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointpath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointpath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);

        _timeToWaypoint = distanceToWaypoint / _speed;
    }
}
