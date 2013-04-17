
namespace net.willshouse.HogKeys.Boards
{
    public interface IAnalogInputs:IInputs
    {
        int PollAnalogIndex(int index);
        int AnalogInputCount { get; }
    }
}
