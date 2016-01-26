namespace Mathproc.Processors
{
    public class ProccessÂûçîâ : IProcessor
    {
        public bool Proccess(string atom, AbstractTreeItem seed, out AbstractTreeItem item)
        {
            if (atom.StartsWith("ÂÛÇÎÂ"))
            {
                item = new TreeItemCall();
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