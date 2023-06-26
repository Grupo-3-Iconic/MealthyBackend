using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Services;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MenuService(IMenuRepository menuRepository, IUnitOfWork unitOfWork)
    {
        _menuRepository = menuRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Menu>> ListAsync()
    {
        return await _menuRepository.ListAsync();
    }

    public async Task<MenuResponse> SaveAsync(Menu menu)
    {
        try
        {
            var existingMenu = await _menuRepository.FindByTitleAsync(menu.Title);
            
            if (existingMenu != null)
                return new MenuResponse("Ya existe un menu con el mismo nombre");

            await _menuRepository.AddAsync(menu);
            await _unitOfWork.CompleteAsync();
            return new MenuResponse(menu);
        }
        catch (Exception e)
        {
            return new MenuResponse($"Ocurrió un error al guardar el menú: {e.Message}");
        }
    }

    public async Task<MenuResponse> UpdateAsync(int id, Menu menu)
    {
        var existingMenu = await _menuRepository.FindByIdAsync(id);
        
        if (existingMenu == null)
            return new MenuResponse("Menu no encontrado.");
        
        existingMenu.Description = menu.Description;
        
        try {
            _menuRepository.Update(existingMenu);
            await _unitOfWork.CompleteAsync();
            return new MenuResponse(existingMenu);
        }
        catch (Exception e) {
            return new MenuResponse($"Ocurrió un error al actualizar el menú: {e.Message}");
        }
    }

    public async Task<MenuResponse> DeleteAsync(int id)
    {
        var existingMenu = await _menuRepository.FindByIdAsync(id);
        
        if (existingMenu == null)
            return new MenuResponse("Menu no encontrado.");
        
        try {
            _menuRepository.Remove(existingMenu);
            await _unitOfWork.CompleteAsync();
            return new MenuResponse(existingMenu);
        }
        catch (Exception e) {
            return new MenuResponse($"Ocurrió un error al borrar el menú: {e.Message}");
        }
    }
}