using UnityEngine;

public class WayPointsMover : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed;
    
    private Transform _wayPoint;
    private int _wayPointIndex;
    
    private void Start() 
    {
        _wayPoints = new Transform[_wayPoint.childCount];

        for (int i = 0; i < _wayPoint.Length; i++)
        {
            _wayPoints[i] = _wayPoint.GetChild(i);
        }
    }

    private void Update()
    {
        var currentWayPoint = _wayPoints[_wayPointIndex];
        
        transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.position, _speed * Time.deltaTime);

        if (transform.position == currentWayPoint.position)
        {
            GetNextWayPoint();
        } 
    }
    
    private void GetNextWayPoint()
    {
        _wayPointIndex++;

        if (_wayPointIndex == _wayPoints.Length)
        {
            _wayPointIndex = 0;
        }
       
        var targetPosition = _wayPoints[_wayPointIndex].transform.position;
        
        transform.forward = targetPosition - transform.position;       
    }
}