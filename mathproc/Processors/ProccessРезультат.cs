namespace Mathproc.Processors
{
    public class Proccess–ÂÁÛÎ¸Ú‡Ú : IProcessor
    {
        public bool Proccess(string atom, AbstractTreeItem seed, out AbstractTreeItem item)
        {
            if (atom.StartsWith("–≈«”À“¿“"))
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