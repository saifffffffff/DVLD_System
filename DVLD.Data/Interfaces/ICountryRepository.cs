using System;

using DVLD_Data.Dtos;

namespace DVLD_Data.Interfaces
{
    public interface ICountryRepository : IGenericRepository<CountryDto>
    {
        string GetCountryName(int Id);
        int GetCountryId(string Name);
    }
}
