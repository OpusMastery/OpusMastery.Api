namespace OpusMastery.Domain.Identity;

public sealed class DisposableAction : IDisposable    
{
    private Action? _dispose;

    private DisposableAction(Action dispose)    
    {
        _dispose = dispose ?? throw new ArgumentNullException(nameof(dispose));
    }

    public void Dispose()    
    {
        Dispose(true);
    }

    private void Dispose(bool isDisposing)
    {
        if (!isDisposing || _dispose is null)
        {
            return;
        }

        _dispose();
        _dispose = null;
    }

    public static DisposableAction Create(Action dispose)
    {
        return new DisposableAction(dispose);
    }
}