using Microsoft.EntityFrameworkCore;
using SoftplanWebAPI.Entities;
using System.Collections.Generic;

namespace SoftplanWebAPI.Service.Interfaces
{
    public interface ISalaService
    {
        List<SalaEntity> BuscaSala();
    }
}
