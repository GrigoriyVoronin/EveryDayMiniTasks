using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualMachine.Core.Debugger.Model;
using VirtualMachine.CPU;
using System;

namespace VirtualMachine.Core.Debugger.Client.Commands
{
    public class AddBreakPointConditionCommand : ICommand
    {


        public uint Result = 0;
        public string Name { get; } = "bp-add-c";
        public string Info { get; } = "Add break point with condition";
        public IReadOnlyList<string> ParameterNames { get; } = new[] { "name", "address", "condition" };
        public Task ExecuteAsync(DebuggerModel model, string[] parameters)
        {
            var bp = new BreakPointDto
            {
                Name = parameters[0],
                Address = Convert.ToUInt32(parameters[1], 16)
            };

            if (CalculateValueOfCondition(model,parameters[2]))
            {
                return model.Client.AddBreakPointCondition(bp);
            }
            else
            {
                return model.Client.ContinueAsync();
            }
        }
        private bool CalculateValueOfCondition(DebuggerModel model,string condition)
        {
            var elementsOfCondition = condition.Split();
            var firstElementValue = CalculateValue(model, elementsOfCondition[0]);
            var secondElementValue = CalculateValue(model, elementsOfCondition[2]);
            return CompareValues(firstElementValue, secondElementValue, elementsOfCondition[1]);

        }
        private bool CompareValues(uint first, uint second, string strOfOperator)
        {
            switch (strOfOperator)
            {
                case "==":
                    return first == second;
                case "!=":
                    return first != second;
                case "<=":
                    return first <= second;
                case "<":
                    return first < second;
                case ">=":
                    return first >= second;
                case ">":
                    return first > second;
                default:
                    throw new Exception();
            }

        }

        private uint CalculateValue(DebuggerModel model, string element)
        {
            if (element.StartsWith("mem("))
            {
                var adress = element.Substring(4, element.Length - 5);
                FindValueOnAdress(model, adress);
                return Result;
            }
            else
               return Convert.ToUInt32(element, 16);
        }

        private async void FindValueOnAdress(DebuggerModel model,string addres)
        {
            var from = Convert.ToUInt32(addres, 16);
            Result = await model.Client.ReadWordAsync(from).ConfigureAwait(true);
            Console.WriteLine(Result);
        }
    }
}