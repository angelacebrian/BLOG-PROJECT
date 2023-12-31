﻿using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(User dto);
    Task<User?> findById(int id);
    Task<User?> UpdateUser(User user);
    Task deleteById(int deleteId);
    Task<User> GetUserByEmail(string email);
    int id { get; set; }
}