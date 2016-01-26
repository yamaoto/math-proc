namespace Mathproc.Processors
{
    public class Proccess≈ÒÎË: IProcessor
    {
        public bool Proccess(string atom, AbstractTreeItem seed, out AbstractTreeItem item)
        {
            if (atom.StartsWith("≈—À»"))
            {
                item = new TreeItemCond();
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