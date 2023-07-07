using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterCollision : MonoBehaviour
    {
        public Action OnCollisionUp { get; set; }

        [Header("Data collision")]
        [SerializeField] private Bounds _characterBounds;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private int _detectorCount = 3;
        [SerializeField] private float _detectionRayLength = 0.1f;

        [Header("Fix position")]
        [Tooltip("Prevents side detectors hitting the ground")]
        [SerializeField]
        [Range(0.1f, 0.3f)] private float _rayBuffer = 0.1f;

        private RayRange _raysUp;
        private bool _colUp;

        public void CheckCollisionCharacter()
        {
            CalculateAndSetRayRanged();

            DetectAllCollisionSide();
        }

        private void CalculateAndSetRayRanged()
        {
            var currentBound = new Bounds(transform.position, _characterBounds.size);

            _raysUp = new RayRange(currentBound.min.x + _rayBuffer, currentBound.max.y, currentBound.max.x - _rayBuffer, currentBound.max.y, Vector2.up);
        }

        private void DetectAllCollisionSide()
        {
            _colUp = IsColliderInTheRangeDetection(_raysUp);

            if (_colUp)
                OnCollisionUp?.Invoke();

        }

        private bool IsColliderInTheRangeDetection(RayRange range)
        {
            return GetAllRayPositions(range).Any(point => Physics2D.Raycast(point, range.Dir, _detectionRayLength, _groundLayer));
        }

        private IEnumerable<Vector2> GetAllRayPositions(RayRange range)
        {
            for (var i = 0; i < _detectorCount; i++)
            {
                var moveVectorDistance = (float)i / (_detectorCount - 1);
                yield return Vector2.Lerp(range.Start, range.End, moveVectorDistance);
            }
        }

        private void OnDrawGizmos()
        {
            // Bounds
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position + _characterBounds.center, _characterBounds.size);

            // Rays
            if (!Application.isPlaying)
            {
                CalculateAndSetRayRanged();
                Gizmos.color = Color.blue;
                foreach (var range in new List<RayRange> { _raysUp})
                {
                    foreach (var point in GetAllRayPositions(range))
                    {
                        Gizmos.DrawRay(point, range.Dir * _detectionRayLength);
                    }
                }
            }

            if (!Application.isPlaying) return;

            // Draw the future position. Handy for visualizing gravity
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, _characterBounds.size);
        }
    }
}