
using Prep.Interfaces.Arguments.Core;
using Prep.Interfaces.Common;
using Prep.Interfaces.Common.Prep.Interfaces.Common;
using Prep.Interfaces.DataObjects;

namespace Prep.Core
{
    public class ValidateEntity1Command : ICommand<ValidateEntity1, TestEntity1>
    {
        public Task<CommandResult<TestEntity1>> Execute(ValidateEntity1 input)
        {


            return Task.FromResult(new CommandResult<TestEntity1>(input.Entity));
        }
    }
}
