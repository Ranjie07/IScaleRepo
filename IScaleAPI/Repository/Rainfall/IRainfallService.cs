using IScaleAPI.ViewModel;

namespace IScaleAPI.Repository.Rainfall
{
    public interface IRainfallService
    {
        public Task<RainfallViewModel> LoadMessurement(int id);
    }
}
