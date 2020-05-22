using VirtualMachine.Core;
using VirtualMachine.CPU;

namespace VirtualMachine.CPU.InstructionSet.Instructions
{
    public class Exit : InstructionBase
    {
        public Exit( ) : base(8, OperandType.Ignored, OperandType.Ignored, OperandType.Ignored)
        { }

        protected override void ExecuteInternal(ICpu cpu, IMemory memory,Operand __,Operand ___, Operand ____)
        {
            Cpu.CpuStoped = true;
        }
    }
}