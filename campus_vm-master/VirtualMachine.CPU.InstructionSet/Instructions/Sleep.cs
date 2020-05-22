using VirtualMachine.Core;
using System.Threading;
using System;

namespace VirtualMachine.CPU.InstructionSet.Instructions
{
    public class Sleep : InstructionBase
    {
        public Sleep(OperandType first) : base(9, first, OperandType.Ignored, OperandType.Ignored)
        { }

        protected override void ExecuteInternal(ICpu _, IMemory __, Operand time, Operand ___, Operand ____)
        {
            TimeSpan SleepTime = TimeSpan.FromMilliseconds(time.Value.ToUInt());
            Thread.Sleep(SleepTime);
        }
    }
}