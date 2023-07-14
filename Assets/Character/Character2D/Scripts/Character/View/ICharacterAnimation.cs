namespace Runtime.Character2D
{
    public interface ICharacterAnimation
    {
        void RotateCharacter();
        void UpdateAnimation(bool _walk, bool sprint);
        void UpdateGroundAnimation(bool isGrounded, float airOffset);
        void AttackAnimation(string nameAttack);
    }
}