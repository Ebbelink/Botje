using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logger.AzureTableStorage;

internal interface ITableDataAccessor<External, Internal>
    where External : new()
    where Internal : new()
{
    Task<External> Add(External entity);

    Task<IEnumerable<External>> Get();

    Task<IEnumerable<External>> Get(Func<Internal, bool> predicate);

    Task<External> Get(int id);

    Task Update(External entity);

    Task<bool> Delete(int id);
}
