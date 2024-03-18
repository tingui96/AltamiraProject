namespace Contracts.Services
{
    public interface IServiceManager
    {
        IUserServices UserService { get; }
        IAuthService AuthService { get; }
        IObraService ObraService { get; }
        IRoleService RoleService { get; }
        IImageService ImageService { get; }

    }
}
