namespace Mathproc.Processors
{
    public class Proccess������ : IProcessor
    {
        public bool Proccess(string atom, AbstractTreeItem seed, out AbstractTreeItem item)
        {
            if (atom.StartsWith("��"))
            {
                item = new TreeItemCond();
                if (seed.Type == TreeItemType.����)
                {

                }
                else
                {
                    seed.Error = true;
                    seed.ErrorCode = ErrorCodes.TP_����_1;
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