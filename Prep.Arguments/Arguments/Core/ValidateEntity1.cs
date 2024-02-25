using Prep.Interfaces.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prep.Interfaces.Arguments.Core
{
    public record ValidateEntity1(TestEntity1 Entity, TestEntity1 OldEntity)
    {

    }
}
