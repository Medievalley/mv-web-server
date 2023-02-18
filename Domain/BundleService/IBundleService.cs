using DataTransferObjects.BundleDTOs;

namespace Domain.BundleService
{
    public interface IBundleService
    {
        Task<bool> CreateBundle(CreateBundleDto bundleDTO);
        Task<bool> UpdateBundle(UpdateBundleDto bundleDTO);
        Task<bool> DeleteBundle(Guid bundleId);
        Task<GetBundleDto> GetBundle(Guid bundleId);
        Task<List<GetBundleDto>> GetBundles();
    }
}
