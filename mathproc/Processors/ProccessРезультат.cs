namespace Mathproc.Processors
{
    public class Proccess��������� : IProcessor
    {
        public bool Proccess(string atom, AbstractTreeItem seed, out AbstractTreeItem item)
        {
            if (atom.StartsWith("��������"))
            {
                item = new TreeItemEnd();
                return true;
            }
            else
            {
                item = null;
                return false;
            }
        }
    }
}