namespace DependencyInversion.Core
{
    using System;
    using Models;
    using Models.Contracts;
    using Models.Strategies;

    public class Engine
    {
        private ICalculator calculator;

        public Engine()
        {
            this.calculator = new PrimitiveCalculator();
        }

        public void Run()
        {
            string input;
            while((input = Console.ReadLine()) != "End")
            {
                string[] inputTokens = input.Split();

                if(inputTokens[0] == "mode")
                {
                    char @operator = inputTokens[1][0];

                    IStrategy strategy = null;

                    switch (@operator)
                    {
                        case '+':
                            strategy = new AdditionStrategy();
                            break;
                        case '-':
                            strategy = new SubtractionStrategy();
                            break;
                        case '*':
                            strategy = new MultiplyingStrategy();
                            break;
                        case '/':
                            strategy = new DividingStrategy();
                            break;
                    }

                    this.calculator.ChangeStrategy(strategy);
                }
                else
                {
                    int firstOperand = int.Parse(inputTokens[0]);
                    int secondOperand = int.Parse(inputTokens[1]);
                    Console.WriteLine(this.calculator.PerformCalculation(firstOperand, secondOperand));
                }
            }
        }
    }
}
