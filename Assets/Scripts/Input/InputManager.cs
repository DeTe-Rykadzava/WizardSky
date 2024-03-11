using JetBrains.Annotations;

public class InputManager
{
    [CanBeNull] private static AInput _currentInput = null;
    [CanBeNull] private static AMouseInput _currentMouseInput = null;

    public static AInput CurrentInput => _currentInput ??= new KeyBoardInput();
    public static AMouseInput CurrentMouseInput => _currentMouseInput ??= new MouseInput();
}
