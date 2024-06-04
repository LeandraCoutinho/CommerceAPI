using CommerceAPI.Application.DTOs;

namespace CommerceAPI.Application.Services.Interfaces;

public interface IPersonImageService
{
    Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDto);
    Task<ResultService> CreateImageAsync(PersonImageDTO personImageDto);
}