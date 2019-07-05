using System;

namespace RazorPagesMovie.Models
{
    //Esta clase fue creada para implementar el patrón observable, cuando se cree una nueva instancia de
    //esta clase con Costs cost = new Costs(numero) se notificara a todos los obvservers subscritos.
    //Debido a complicaciones con el framework y falta de tiempo, esta clase nunca es utilizada.
    public class Costs
    {
        private int Salary;
        public Costs(int salary)
        {
            Salary = salary;
        }

    }
}