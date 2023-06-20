namespace Runtime.InputSystem
{
    public class ControlInputBoolOnePress : ControlInputBool
    {
        public override bool IsInputPressed 
        {
            get 
            {
                if (_isInputPressed)
                {
                    _isInputPressed = false;
                    return true;
                }
                return _isInputPressed;
            }
            set => _isInputPressed = value;
        }
    }
}
