
namespace net.willshouse.HogKeys.IO
{
    public interface IState<T>
    {
         bool isStateChanged(T[] values);
         string generateState(T[] values);
    }
}
