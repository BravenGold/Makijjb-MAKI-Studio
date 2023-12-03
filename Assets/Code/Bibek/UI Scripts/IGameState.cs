public interface IGameState
{
    // Called when entering the state
    void EnterState();

    // Called each frame while in the state
    void UpdateState();

    // Called when exiting the state
    void ExitState();
}

