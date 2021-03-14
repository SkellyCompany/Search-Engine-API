﻿using SearchEngine.API.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngine.API.Core.DomainServices
{
    public interface ITermRepository
    {
        Task<IEnumerable<DocumentInTerm>> Search(string term);
    }
}