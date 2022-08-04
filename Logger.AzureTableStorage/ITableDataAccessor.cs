using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logger.AzureTableStorage;

internal interface ITableDataAccessor<External>
    where External : new()
{
    Task Add(External entity);

    //Task<IEnumerable<External>> Get();

    //Task<IEnumerable<External>> Get(Func<Internal, bool> predicate);

    //Task<External> Get(int id);

    //Task Update(External entity);

    //Task<bool> Delete(int id);
}
