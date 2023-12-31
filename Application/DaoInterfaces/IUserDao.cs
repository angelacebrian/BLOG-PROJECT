﻿using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    void CreateAsync(User user);
    User? GetByEmailAsync(string email);
    User? GetByIdAsync(int id);
    void UpdateUser(User user);
    void deleteUser(int id);
}