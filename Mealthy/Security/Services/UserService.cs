
using AutoMapper;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Security.Domain.Models;
using Mealthy.Security.Domain.Repositories;
using Mealthy.Security.Domain.Services;
using Mealthy.Security.Domain.Services.Communication;
using Mealthy.Security.Exceptions;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Mealthy.Security.Services;

public class UserService : IUserservice
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User Not Found");
        return user;
    }

    public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        throw new NotImplementedException();
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        //validate
        if (_userRepository.ExistsByUsername(request.Username))
            throw new AppException("Username '" + request.Username + "'is already taken");
        //map model to new user object 
        var user = _mapper.Map<User>(request);
        // hash password
        user.PasswordHash = BCryptNet.HashPassword(request.Password);

        //save user
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error ocurred while saving the user: {e.Message}");

        }
        //helper methods

    }

    private User GetById(int id)
    {
        var user = _userRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task UpdateAsync(int id, UpdateRequest request)
    {
        var user = GetById(id);
        //validate 
        if (_userRepository.ExistsByUsername(request.Username))
            throw new AppException("Username '" + request.Username + "' is already taken");
        //Hash password if it was entered
        if (!string.IsNullOrEmpty(request.Password))
            user.PasswordHash = BCryptNet.HashPassword(request.Password);

        //copy model to user and save
        _mapper.Map(request, user);
        try
        {
            _userRepository.Update(user);
            await _unitOfWork.CompleteAsync();

        }
        catch (Exception e)
        {
            throw new AppException($"An error ocurred while updating the user: {e.Message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = GetById(id);
        try
        {
            _userRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error ocurred while deleting the user: {e.Message}");
        }


    }
}