namespace Mathproc.Processors
{
    public class Proccess≈ÒÎË“Ó : IProcessor
    {
        public bool Proccess(string atom, AbstractTreeItem seed, out AbstractTreeItem item)
        {
            if (atom.StartsWith("“Œ"))
            {
                item = new TreeItemCond();
                if (seed.Type == TreeItemType.≈ÒÎË)
                {

                }
                else
                {
                    seed.Error = true;
                    seed.ErrorCode = ErrorCodes.TP_≈ÒÎË_1;
                }
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