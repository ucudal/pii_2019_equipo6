using System;
using System.Collections.Generic;

namespace RazorPagesMovie.Models
{
    public class TemperatureReporter : IObserver<Costs>
    {
        private IDisposable unsubscriber;
        private bool first = true;
        private Costs last;
        public virtual void Subscribe(IObservable<Costs> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
        public virtual void OnCompleted() 
        {
            //No hace nada
        }

        public virtual void OnError(Exception error)
        {
            //No hace nada
        }

        public virtual void OnNext(Costs value)
        {
            //Si el salario correspondiente a la especialización de un técnico es editado, este metodo
            //actualizará el presupuesto de los proyectos a los que dicho técnico este asignado
        }
    }
}