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

        for (int i = 0; i < _wayPoint.childCount; i++)
        {
            _wayPoints[i] = _wayPoint.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        var _currentWayPoint = _wayPoints[_wayPointIndex];
        
        transform.position = Vector3.MoveTowards(transform.position, _currentWayPoint.position, _speed * Time.deltaTime);

        if (transform.position == _currentWayPoint.position)
        {
            GetNextWayPoint();
        } 
    }
    
    private Vector3 GetNextWayPoint()
    {
        _wayPointIndex++;

        if (_wayPointIndex == _wayPoints.Length)
        {
            _wayPointIndex = 0;
        }
        
        var movingDirection = _wayPoints[_wayPointIndex].transform.position;
        
        transform.forward = movingDirection - transform.position;
        
        return movingDirection;
    }
}