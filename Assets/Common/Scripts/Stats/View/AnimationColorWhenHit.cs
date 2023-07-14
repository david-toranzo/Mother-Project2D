using UnityEngine;

namespace Common
{

    public class AnimationColorWhenHit : AnimationColorWhenHitBase
    {
        [SerializeField] private SpriteRenderer _spriteHit;

        protected override void SetColorAnimation(Color colorToSet)
        {
            _spriteHit.material.color = colorToSet;
        }
    }
}