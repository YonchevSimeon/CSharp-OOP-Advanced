namespace BlackBoxIntergerExercise
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine
    {
        private Type classType;
        private object blackBoxInteger;
        private MethodInfo[] methods;
        private FieldInfo innerValue;

        public Engine()
        {
            this.classType = typeof(BlackBoxInteger);
            this.blackBoxInteger = Activator.CreateInstance(this.classType, true);
            this.methods = this.classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            this.innerValue = this.classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public void Run()
        {
            string input;
            
            while((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split('_');

                string methodName = inputArgs[0];
                int integer = int.Parse(inputArgs[1]);

                this.methods.First(m => m.Name == methodName)
                    .Invoke(this.blackBoxInteger, new object[] { integer });
                
                Console.WriteLine(this.innerValue.GetValue(this.blackBoxInteger));
            }
        }
    }
}
