using System.ComponentModel.DataAnnotations;

namespace MediatorFlyweightFactory.Contracts.Requests;

public record MyRegisterRequest(
    [Required, EmailAddress] string Email,
    string Password,
    string Role
    );