namespace Mathproc.Processors
{
    public interface IProcessor
    {
        bool Proccess(string atom, AbstractTreeItem seed, out AbstractTreeItem item);
    }
}