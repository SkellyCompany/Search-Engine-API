﻿using SearchEngine.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngine.Core.DomainServices
{
    public interface IDocumentRepo
    {
        Task<Document> GetById(string id);
        Task<IEnumerable<Document>> GetDocumentsFromDocTable();
    }
}
