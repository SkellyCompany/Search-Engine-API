﻿using SearchEngine.API.Core.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngine.API.Core.ApplicationServices
{
    public interface IDocumentService
    {
        Task<Document> GetById(string id);
        Task<IEnumerable<Document>> GetDocumentsFromDocTable();
    }
}
