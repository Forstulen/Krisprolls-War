using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public enum FollowingPath
    {
        MAIN_PATH = 0,
        ALTERNATIVE_PATH1,
        ALTERNATIVE_PATH2,
        ALTERNATIVE_PATH3
    }

    public class FollowingWaypointScript : MonoBehaviour
    {

        //Events
        public delegate void OnFollowingEvent(GameObject obj);
        public event OnFollowingEvent StartFollowing;
        public event OnFollowingEvent StopFollowing;
        public event OnFollowingEvent FinishFollowing;

        //public attributes
        public float            MovementSpeed = 2.0f;
        public bool             IsLooping = false;
        public bool             IsRotating = false;
        public FollowingPath    FollowingPath = FollowingPath.MAIN_PATH;


        //private attributes
        protected int _currentWayPoint = 0;
        private Transform _waypointsParent;
        private bool _shouldWalk;
        private bool _isInReverseMode;
        private Dictionary<FollowingPath, Transform> _followingPaths;

        private float _offsetX;
        private float _offsetY;

        //const attributes
        private const string _waypointsParentName = "Waypoints";
        private const string _mainPathName = "MainPath";
        private const string _alternativePath1Name = "AlternativePath1";
        private const string _alternativePath2Name = "AlternativePath2";
        private const string _alternativePath3Name = "AlternativePath3";

        protected void Awake()
        {
            _waypointsParent = GameObject.Find(_waypointsParentName).transform;
            _followingPaths = new Dictionary<FollowingPath, Transform>();

            foreach (Transform t in _waypointsParent)
            {
                switch (t.name)
                {
                    case _mainPathName:
                        _followingPaths.Add(FollowingPath.MAIN_PATH, t);
                        break;
                    case _alternativePath1Name:
                        _followingPaths.Add(FollowingPath.ALTERNATIVE_PATH1, t);
                        break;
                    case _alternativePath2Name:
                        _followingPaths.Add(FollowingPath.ALTERNATIVE_PATH2, t);
                        break;
                    default:
                        _followingPaths.Add(FollowingPath.ALTERNATIVE_PATH3, t);
                        break;
                }
            }

            if (_waypointsParent == null)
                throw new System.Exception("FollowingWayPointScript: Check if the waypoints object exists");
        }

        // Use this for initialization
        protected void Start()
        {
 
        }

        public Vector3 GetInitialPosition() {
            return GetTransform().GetChild(0).position;
        }

        //Public Methods
        public void StartWalking()
        {
            _shouldWalk = true;

            if (StartFollowing != null)
                StartFollowing(gameObject);
        }

        public void StopWalking()
        {
            _shouldWalk = false;

            if (StopFollowing != null)
                StopFollowing(gameObject);
        }

        public void ResetTarget() {
            _currentWayPoint = 0;
        }

        //Private Methods
        protected virtual void Update()
        {
            if (_shouldWalk)
                HandleWalkWaypoints();
        }

        private Transform GetTransform() {
            return _followingPaths[FollowingPath];
        }

        // Handle walking the waypoints
        private void HandleWalkWaypoints()
        {
            Transform targetWaypoint = GetTransform().GetChild(_currentWayPoint);
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(targetWaypoint.position.x + _offsetX, targetWaypoint.position.y + _offsetY), MovementSpeed * Time.deltaTime);

            Vector3 vectorToTarget = new Vector3(targetWaypoint.position.x + _offsetX, targetWaypoint.position.y + _offsetY, 0.0f) - transform.position;
            float distanceToWaypoint = vectorToTarget.magnitude;

            if (IsRotating)
            {
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * MovementSpeed * 2.0f);
            }           

            if (distanceToWaypoint < 0.1)
            {
                _offsetX = Random.Range(0.0f, 0.25f);
                _offsetY = Random.Range(0.0f, 0.25f);
                if (_isInReverseMode) {
                    if (_currentWayPoint - 1 > 0)
                    {
                        // Set new waypoint as target
                        _currentWayPoint--;
                    }
                    else
                    {
                        _isInReverseMode = false;
                        _currentWayPoint = 0;
                    }
                } else {
                    if (_currentWayPoint + 1 < GetTransform().childCount)
                    {
                        // Set new waypoint as target
                        _currentWayPoint++;
                    }
                    else
                    {
                        if (IsLooping)
                        {
                            _isInReverseMode = true;
                        }
                        else
                        {
                            _shouldWalk = false;
                            if (FinishFollowing != null)
                                FinishFollowing(gameObject);
                            return;
                        }
                    }
                }

            }
        }
    }

}
