namespace CrossChainMonitor.Observers;

public interface IObserverFactory{

    public IObserver CreateObserver(string observerType);

}