using FluentValidation.Results;
using CommerceAPI.Application.DTOs;

namespace CommerceAPI.Application.Services;

public class ResultService
{
    // responsável por tratar o retorno dos serviçoes
    public bool IsSucsess { get; set; }
    public string Message { get; set; }
    public ICollection<ErrorValidation> Errors { get; set; }

    public static ResultService RequestError(string message, ValidationResult validationResult)
    {
        return new ResultService
        {
            IsSucsess = false,
            Message = message,
            Errors = validationResult.Errors
                .Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
        };
    }
    
    public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
    {
        return new ResultService<T>
        {
            IsSucsess = false,
            Message = message,
            Errors = validationResult.Errors
                .Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
        };
    }

    public static ResultService Fail(string message) => new ResultService { IsSucsess = false, Message = message };
    public static ResultService<T> Fail<T>(string message) => new ResultService<T> { IsSucsess = false, Message = message };
    
    public static ResultService Ok(string message) => new ResultService { IsSucsess =true, Message = message };
    public static ResultService<T> Ok<T>(T data) => new ResultService<T> { IsSucsess = true, Data = data};
}

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }