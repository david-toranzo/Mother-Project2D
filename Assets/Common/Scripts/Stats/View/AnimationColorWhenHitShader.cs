using UnityEngine;

namespace Common
{
    public class AnimationColorWhenHitShader : AnimationColorWhenHitBase
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        protected override void SetColorAnimation(Color colorToSet)
        {
            _meshRenderer.material.SetColor("_MainColor", colorToSet);
        }
    }
}