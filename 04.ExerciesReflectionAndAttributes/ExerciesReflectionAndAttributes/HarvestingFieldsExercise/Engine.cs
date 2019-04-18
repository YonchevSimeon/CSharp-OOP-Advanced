namespace HarvestingFieldsExercise
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine
    {
        public void Run()
        {
            Type classType = typeof(HarvestingFields);

            FieldInfo[] classFields = classType
                .GetFields
                (
                    BindingFlags.Instance |
                    BindingFlags.NonPublic |
                    BindingFlags.Public
                );

            string input;

            while ((input = Console.ReadLine()) != "HARVEST")
            {
                switch (input)
                {
                    case "private":
                        PrintFields(classFields.Where(f => f.IsPrivate).ToArray());
                        break;

                    case "protected":
                        PrintFields(classFields.Where(f => f.IsFamily).ToArray());
                        break;

                    case "public":
                        PrintFields(classFields.Where(f => f.IsPublic).ToArray());
                        break;

                    case "all":
                        PrintFields(classFields);
                        break;
                }
            }
        }

        private void PrintFields(FieldInfo[] fields)
        {
            foreach (FieldInfo field in fields)
            {
                string accessModifier = field.Attributes.ToString().ToLower();
                string fieldType = field.FieldType.Name;
                string fieldName = field.Name;

                if (accessModifier == "family")
                    accessModifier = "protected";

                Console.WriteLine($"{accessModifier} {fieldType} {fieldName}");
            }
        }
    }
}

