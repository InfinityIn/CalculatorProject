namespace CalculatorLibrary
{
    public interface IController
    {
        public void Notify(Operation operation, string message, int? result);
    }

    public class Controller : IController
    {
        private Addition addition;
        private Subtraction subtraction;
        public Controller(Addition addition, Subtraction subtraction)
        {
            this.addition = addition;
            this.subtraction = subtraction;
            addition.SetMediator(this);
            subtraction.SetMediator(this);
        }

        public void Notify(Operation operation, string message, int? result)
        {
            if (operation is Addition)
            {
                Console.WriteLine($"{message}, результат сложения: {result}");
            }
            if (operation is Subtraction)
            {
                Console.WriteLine($"{message}, результат вычитания: {result}");
            }
        }
              
    }

    public abstract class Operation
    {
        protected IController controller;

        public Operation(IController controller) => this.controller = controller;

        public void SetMediator(IController controller) => this.controller = controller;
    }

    public class Addition : Operation
    {
        public Addition(IController controller = null) : base(controller) { }

        public void Calc(int num1, int num2)
        {
            try
            {
                var result = num1 + num2;
                controller.Notify(this, "Операция произошла успешно", result);
            }
            catch(Exception e)
            {
                controller.Notify(this, $"При выполнении операции возникли ошибки : {e.Message}", null);
            }            
        }
        
    }

    public class Subtraction : Operation
    {
        public Subtraction(IController controller = null) : base(controller) { }

        public void Calc(int num1, int num2)
        {
            try
            {
                var result = num1 - num2;
                controller.Notify(this, "Операция произошла успешно", result);
            }
            catch (Exception e)
            {
                controller.Notify(this, $"При выполнении операции возникли ошибки : {e.Message}", null);
            }
        }

    }

}