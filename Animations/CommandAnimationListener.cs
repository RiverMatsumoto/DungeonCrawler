using System;

public class CommandAnimationListener
{
    private Action method;

    public CommandAnimationListener(Action method)
    {
        this.method = method;
        Subscribe();
    }

    private void witness()
    {
        method.Invoke();
        Unsubscribe();
    }

    public void Subscribe() => CommandAnimation._animationEnded += witness;

    public void Unsubscribe() => CommandAnimation._animationEnded -= witness;
}
