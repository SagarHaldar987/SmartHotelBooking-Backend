using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartHotelBooking.DTOs;
using SmartHotelBooking.Helpers;
using SmartHotelBooking.Models;
using SmartHotelBooking.Repositories.Interfaces;
using SmartHotelBooking.Services.Interfaces;

namespace SmartHotelBooking.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid email or password.");

            // Verify password
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid email or password! Please Register.");

            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDto
            {
                Message = "Login SuccessFull",
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Token = token,
                UserId = user.UserId
            };
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            var newUser = new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                PasswordHash = hashedPassword,
                Role = registerDto.Role,
                ContactNumber = registerDto.ContactNumber
            };

            // ✅ Save and get back the generated UserId
            var createdUser = await _userRepository.AddAsync(newUser);

            // ✅ Generate token
            var token = _jwtService.GenerateToken(createdUser);

            return new AuthResponseDto
            {
                Message = "Registration SuccessFull",
                Name = createdUser.Name,
                Email = createdUser.Email,
                Role = createdUser.Role,
                UserId = createdUser.UserId,  // ✅ Will now be correct
               // Token = token
            };
        }
    }
}
