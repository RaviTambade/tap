using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class CustomerRepository : ICustomerRepository
{

    public static string conString="server=localhost;port=3306;user=root;password=Password;database=Ecommerce";

    public List<Customer> GetAllCustomers(){

        List<Customer> customers=new List<Customer>();

        Customer customer=new Customer();
        MySqlConnection connection=new MySqlConnection(conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText=$"SELECT * FROM customers";
            command.Connection=connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 int id = Int32.Parse(reader["cust_id"].ToString());
                string? firstname = reader["first_name"].ToString();
                string? lastname = reader["last_name"].ToString();
                string? email = reader["email"].ToString();
                string? contact=reader["contact_number"].ToString();
                customer = new Customer
                {
                   CustomerId=id,
                   FirstName=firstname,
                   LastName=lastname,
                   Email=email,
                   ContactNumber=contact
                };
                customers.Add(customer);
            }
        }
        catch(Exception e){
            throw e;
        }
        finally{
            connection.Close();
        }
      return customers; 


    }

    public Customer GetCustomer(string contact)
    {
        Customer customer=new Customer();
        MySqlConnection connection=new MySqlConnection(conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText=$"SELECT * FROM customers where contact_number='{contact}'";
            command.Connection=connection;
            connection.Open();
           MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                 int id = Int32.Parse(reader["cust_id"].ToString());
                string? firstname = reader["first_name"].ToString();
                string? lastname = reader["last_name"].ToString();
                string? email = reader["email"].ToString();
                

                 customer = new Customer
                {
                   CustomerId=id,
                   FirstName=firstname,
                   LastName=lastname,
                   Email=email,
                   ContactNumber=contact
                };
            
            }
        }
        catch(Exception e){
            throw e;
        }
        finally{
            connection.Close();
        }
      return customer; 

    }

    public Customer GetCustomerById(int custid)
    {
        Customer customer=new Customer();
        MySqlConnection connection=new MySqlConnection(conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText=$"SELECT * FROM customers where cust_id={custid}";
            command.Connection=connection;
            connection.Open();
           MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int id = Int32.Parse(reader["cust_id"].ToString());
                string? firstname = reader["first_name"].ToString();
                string? lastname = reader["last_name"].ToString();
                string? email = reader["email"].ToString();
                   string? contact=reader["contact_number"].ToString();
                customer = new Customer
                {
                   CustomerId=id,
                   FirstName=firstname,
                   LastName=lastname,
                   Email=email,
                   ContactNumber=contact
                };
            
            }
        }
        catch(Exception e){
            throw e;
        }
        finally{
            connection.Close();
        }
      return customer; 
    }



    public bool InsertCustomer(Customer customer){
        bool status=false;
        MySqlConnection connection=new MySqlConnection(conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText=$"INSERT INTO customers(first_name,last_name,email,contact_number,password)VALUES('{customer.FirstName}','{customer.LastName}','{customer.Email}','{customer.ContactNumber}','{customer.Password}')";
            command.Connection=connection;
            connection.Open();
            command.ExecuteNonQuery();
            status=true;
        }
        catch(Exception e){
            throw e;
        }
        finally{
            connection.Close();
        }
      return status;      
    }

       public  bool UpdateCustomer(Customer customer){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=conString;
        try{
            
            string query = $"Update customers SET first_name ='{customer.FirstName}',last_name ='{customer.LastName}',email='{customer.Email}',contact_number='{customer.ContactNumber}',password ='{customer.Password}' WHERE cust_id='{customer.CustomerId}' ";
            MySqlCommand cmd=new MySqlCommand(query,con) ;
            con.Open();
            cmd.ExecuteNonQuery();               
            status=true;
          }
        catch(Exception e )
          {
            throw e;
          }
          finally {
            con.Close();
          }
          return status;
   }
   
   public  bool DeleteCustomer(int id){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=conString;
          try{
            
            string query = "DELETE FROM customers WHERE cust_id="+id;
            MySqlCommand cmd=new MySqlCommand(query,con) ;
            con.Open();
            cmd.ExecuteNonQuery();  
            status=true;            

          }catch(Exception e )
          {
            throw e;
          }
          finally {
            con.Close();
          }
          return status;
   }

}