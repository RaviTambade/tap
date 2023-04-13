using System;
namespace BankingService.Models;
public class Account
{
    public int AccountId{ get; set; }
    public long AccountNumber{ get; set; }
    public string IFSCCode{ get; set; }
    public DateTime RegisterDate{ get; set; }
    public double Balance{ get; set; }
}