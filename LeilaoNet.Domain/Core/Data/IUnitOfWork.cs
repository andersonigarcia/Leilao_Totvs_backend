using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LailaoNet.Domain.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();

        bool HasChanges();
    }
}
