

namespace Prep.Interfaces.Common
{
    public interface IQuery<Input, Output>
    {
        public Task<CommandResult<Output>> Get(Input input);
    }
}
