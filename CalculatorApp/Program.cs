using CalculatorLibrary;

var addition = new Addition();
var substraction = new Subtraction();

Controller controller = new Controller(addition, substraction);

//Исходные данные
StartCalc(1, 2, OperationType.Addition);

StartCalc(10, 4, OperationType.Substraction);


void StartCalc(int num1, int num2, OperationType operationType)
{
    switch (operationType)
    {
        case OperationType.Addition:
            addition.Calc(num1, num2);
            break;
        case OperationType.Substraction:
            substraction.Calc(num1, num2);
            break;
        default:
            throw new Exception();

    }
}

enum OperationType
{
    Addition,
    Substraction
}