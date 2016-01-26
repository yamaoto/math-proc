namespace Mathproc.Processors
{
    public class ProccessЕслиИначе : IProcessor
    {
        public bool Proccess(string atom, AbstractTreeItem seed, out AbstractTreeItem item)
        {
            if (atom.StartsWith("ИНАЧЕ"))
            {
                item = new TreeItemCond();
                if (seed.Type == TreeItemType.Если || seed.Type == TreeItemType.То)
                {

                }
                else
                {
                    seed.Error = true;
                    seed.ErrorCode = ErrorCodes.TP_Если_2;
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