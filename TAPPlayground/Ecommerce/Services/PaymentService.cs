using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class PaymentService:IPaymentService{
    private readonly IPaymentRepository _repo;
    public PaymentService(IPaymentRepository repo){
        this._repo=repo;
    }

    public List<Payment> GetAllPayments() => _repo.GetAllPayments();
    public Payment GetPaymentById( int paymentId) =>_repo.GetPaymentById(paymentId);
    public Payment GetPaymentByOrderId( int OrderId) =>_repo.GetPaymentById(OrderId);
    
}