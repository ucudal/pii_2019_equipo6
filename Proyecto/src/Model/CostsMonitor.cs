using System;
using System.Collections.Generic;

namespace RazorPagesMovie.Models
{
    public class CostsMonitor : IObservable<Costs>
    {
        List<IObserver<Costs>> observers;
        public CostsMonitor()
    {
          observers = new List<IObserver<Costs>>();
    }
    public IDisposable Subscribe(IObserver<Costs> observer)
        {
            if (! observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }
        private class Unsubscriber : IDisposable
{
   private List<IObserver<Costs>> _observers;
   private IObserver<Costs> _observer;

   public Unsubscriber(List<IObserver<Costs>> observers, IObserver<Costs> observer)
   {
      this._observers = observers;
      this._observer = observer;
   }

   public void Dispose() 
   {
      if (! (_observer == null)) _observers.Remove(_observer);
   }
}
    }
}