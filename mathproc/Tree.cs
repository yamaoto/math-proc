using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathproc.Processors;

namespace Mathproc
{
    public enum TreeItemType
    {
        Если,
        То,
        Иначе,
        Вызов,
        Результат,

        Присвоение,
        Выражение
    }

    public abstract class AbstractTreeItem
    {
        public TreeItemType Type { get; set; }

        public string Content { get; set; }
        public int Line { get; set; }
        public int Pos { get; set; }

        public bool Error { get; set; }
        public ErrorCodes ErrorCode { get; set; }
    }

    public class TreeItem : AbstractTreeItem
    {
        public TreeItem[] Items { get; set; }

        public TreeItem Next { get; set; }
    }

    public class TreeItemCond : AbstractTreeItem
    {
        public TreeItem WhenTrue { get; set; }
        public TreeItem WhenFalse { get; set; }
    }

    public class TreeItemEnd : AbstractTreeItem
    {
    }
    public class TreeItemCall : AbstractTreeItem
    {
        public TreeItem Next { get; set; }
    }


    /// <summary>
    /// Обработка текста в ГЛУБИНУ в виде дерева
    /// </summary>
    public class TreeProcessor
    {
        public readonly AbstractTreeItem Seed;

        public readonly Processors.IProcessor[] Processors;

        public TreeProcessor(string programm)
        {
            Processors = new Processors.IProcessor[]
            {
                new ProccessВыражение(), 
                new ProccessЕсли(),
                new ProccessЕслиТо(),
                new ProccessЕслиИначе(), 
                new ProccessВызов(), 
                new ProccessРезультат(), 
            };
            var atoms = programm.Split(new[] { Environment.NewLine, ";" }, StringSplitOptions.None);
            Seed = _proccess(null, atoms, 0);
        }


        private AbstractTreeItem _proccess(AbstractTreeItem seed, string[] atoms, int i)
        {
            AbstractTreeItem item;
            var conStart = "ЕСЛИ,ТО,ИНАЧЕ,ВЫЗОВ,РЕЗУЛТАТ".Split(new[] { "," }, StringSplitOptions.None); ;
            var atom = atoms[i];
            if (conStart.Any(atom.StartsWith))
            {
                foreach (var processor in Processors)
                {
                    if (processor.Proccess(atom, seed, out item))
                    break;
                }
            }
            else
            {
                //присвоения
            }
            throw new NotImplementedException();
        }
        
        
    }
}
