﻿using AutoMapper;
using SmartHotelBooking.DTOs;
using SmartHotelBooking.Models;

namespace SmartHotelBooking.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Users
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<RegisterUserDto, User>();
            CreateMap<LoginDto, User>();

            // Hotels
            //CreateMap<Hotel, HotelDTO>().ReverseMap();
             CreateMap<Hotel, HotelDTO>()
            .ForMember(dest => dest.HotelID, opt => opt.MapFrom(src => src.HotelId))
            .ForMember(dest => dest.ManagerID, opt => opt.MapFrom(src => src.ManagerId))
            .ReverseMap();
            CreateMap<CreateHotelDto, Hotel>().ReverseMap();
            CreateMap<UpdateHotelDto, Hotel>().ReverseMap();

            // Rooms
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<CreateRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();

            // Bookings
            CreateMap<Booking, BookingDTO>()
            .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Room.Hotel.Name))
            .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.Room.Type))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status ? "Confirmed" : "Cancelled"))
            .ReverseMap();
            //CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<UpdateBookingDto, Booking>().ReverseMap();
            // CreateMap<Booking, BookingDTO>().ReverseMap();
            CreateMap<CreateBookingDto, Booking>()
            .ForMember(dest => dest.CheckInDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.CheckInDate)))
            .ForMember(dest => dest.CheckOutDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.CheckOutDate)))
            .ReverseMap();

            //       CreateMap<Booking, BookingDTO>()
            //.ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Room.Hotel.Name))
            //.ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.Room.Type))
            //.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status ? "Confirmed" : "Cancelled"))
            //.ReverseMap();
            //       CreateMap<CreateBookingDto, Booking>().ReverseMap();
            //       CreateMap<UpdateBookingDto, Booking>().ReverseMap();

            // Payments
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<CreatePaymentDto, Payment>().ReverseMap();

            // Reviews
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<CreateReviewDto, Review>().ReverseMap();

            // Loyalty
            CreateMap<LoyaltyAccount, LoyaltyAccountDTO>().ReverseMap();
            CreateMap<CreateLoyaltyAccountDto, LoyaltyAccount>();
            CreateMap<Redemption, RedemtionDTO>().ReverseMap();
        }
    }
}
