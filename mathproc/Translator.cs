using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathproc
{
    public enum NodeTypeEnum
    {
        Operand,
        Lexemma
    }

    public enum LexemmaTypeEnum
    {
        Ramification,
        Definition,
        Call
    }

    /// <summary>
    /// Трансляция кода в байткод
    /// </summary>
    public abstract class AbstractNode
    {
        public NodeTypeEnum NodeType { get; set; }

        public abstract byte[] Translate();
    }

    public class OperandNode : AbstractNode
    {
        public byte[] Content { get; set; }
        public string ContentType { get; set; }

        public override byte[] Translate()
        {
            throw new NotImplementedException();
        }
    }

    public class LexemmaNode : AbstractNode
    {
        public LexemmaTypeEnum LexemmaType { get; set; }
        public override byte[] Translate()
        {
            throw new NotImplementedException();
        }
    }
}
