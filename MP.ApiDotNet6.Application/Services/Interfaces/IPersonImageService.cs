using MP.ApiDotNet6.Application.DTOs;

namespace MP.ApiDotNet6.Application.Services.Interfaces;

public interface IPersonImageService
{
    Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDto);
    Task<ResultService> CreateImageAsync(PersonImageDTO personImageDto);
}