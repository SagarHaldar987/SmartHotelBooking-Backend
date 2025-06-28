using AutoMapper;
using SmartHotelBooking.DTOs;
using SmartHotelBooking.Models;
using SmartHotelBooking.Repositories.Interfaces;
using SmartHotelBooking.Services.Interfaces;

namespace SmartHotelBooking.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<PaymentDTO> GetPaymentByIdAsync(int paymentId)
        {
            var payment = await _paymentRepository.GetByIdAsync(paymentId);
            return _mapper.Map<PaymentDTO>(payment);
        }

        public async Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync()
        {
            var payments = await _paymentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentDTO>>(payments);
        }

        public async Task<IEnumerable<PaymentDTO>> GetPaymentsByUserIdAsync(int userId)
        {
            var payments = await _paymentRepository.GetPaymentsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<PaymentDTO>>(payments);
        }

        public async Task<PaymentDTO> CreatePaymentAsync(CreatePaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _paymentRepository.AddAsync(payment);
            await _paymentRepository.SaveChangesAsync();
            return _mapper.Map<PaymentDTO>(payment);
        }

        public async Task<bool> UpdatePaymentAsync(int paymentId, UpdatePaymentDto paymentDto)
        {
            var existingPayment = await _paymentRepository.GetByIdAsync(paymentId);
            if (existingPayment == null) return false;

            _mapper.Map(paymentDto, existingPayment);
            _paymentRepository.Update(existingPayment);
            await _paymentRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePaymentAsync(int paymentId)
        {
            var payment = await _paymentRepository.GetByIdAsync(paymentId);
            if (payment == null) return false;

            _paymentRepository.Delete(payment);
            await _paymentRepository.SaveChangesAsync();
            return true;
        }
    }
}
