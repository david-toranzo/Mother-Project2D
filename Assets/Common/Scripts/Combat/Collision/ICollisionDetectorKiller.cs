using System;

namespace Common
{
    public interface ICollisionDetectorKiller
    {
        Action OnKillerCollision { get; set; }
    }
}