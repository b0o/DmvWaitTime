namespace DmvWaitTime.MyJobs
{
    public interface IMyJob<TObject>
    {
        void Execute();
    }
}
