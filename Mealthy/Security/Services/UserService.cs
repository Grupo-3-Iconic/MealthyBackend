
using Mealthy.Security.Domain.Services;
using BCryptNet = BCryptNet.Net.BCryptNet;

namespace Mealthy.Security.Services;
public class UserService : IUservice
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IMapper _mapper;

    public UserService (IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        throw new NoImplementedException();
    }
    public Task<IEnumerable<User>> ListAsync()
    {
        throw new NoImplementedException();
    }
    public Task<User> GetByIdAsync(int id)
    {
        throw new NoImplementedException();
    }
    public Task RegisterAsync(RegisterRequest model)
    {
        throw new NoImplementedException();
    }
    public Task UpdateAsync(int id, UpdateRequest model)
    {
        throw new NoImplementedException();
    }
    public Task DeleteAsync(int id )
    {
        throw new NoImplementedException();
    }

    }