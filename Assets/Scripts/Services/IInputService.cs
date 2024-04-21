using System;

public interface IInputService
{
    public event Action<float> OnMoveButton;
    public event Action OnShoot;
}