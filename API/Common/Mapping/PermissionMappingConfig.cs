using Contracts.Permission;
using Domain.PermissionAggregate;
using Mapster;

namespace API.Common.Mapping
{
    public class PermissionMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Permission, PermissionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}
