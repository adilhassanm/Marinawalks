using Marinawalks.api.Model.Domain;

namespace Marinawalks.api.Repositories
{
    public interface IRegionRepository
    {
        //create a contract/method to get all regions


        Task<IEnumerable<Region>> GetAllAsync();//enumeable in c# is basically generators of vales or numbers,like generate process and then generate etc like generating value from list one by one and processing etc

    }
}
