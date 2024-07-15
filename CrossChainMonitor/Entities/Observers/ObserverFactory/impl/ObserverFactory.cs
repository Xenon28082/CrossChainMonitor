using CrossChainMonitor.Exceptions;

namespace CrossChainMonitor.Observers;

public class ObserverFactory : IObserverFactory
{
    public IObserver CreateObserver(string observerType)
    {
        if (observerType == null)
        {
            throw new ObserverFactoryException("Cannot create observer instance from null");
        }
        try
        {
            return (IObserver)Activator.CreateInstance(Type.GetType(observerType));
        }
        catch
        {
            throw new ObserverFactoryException("Cannot create instance of type " + observerType);
        }

    }
}