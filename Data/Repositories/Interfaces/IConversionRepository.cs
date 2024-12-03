using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IConversionRepository
    {
        void AddConversion(Conversion conversion);
        int GetConversionCountByUserId(int userId);
        List<Conversion> GetConversionsByUserId(int userId);
    }
}