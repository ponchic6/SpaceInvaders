using System;

public interface IInputService
{
    public event Action<int> OnMoveButton;
    public event Action OnShoot;
}