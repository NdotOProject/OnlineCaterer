﻿
namespace OnlineCaterer.Application.DTOs.Users;

public class BasicUserResponse
{
    public string Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string UserName { get; set; }
    public string Password { get; set; }

}