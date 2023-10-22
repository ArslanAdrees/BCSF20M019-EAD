using System;
using System.Data;
using System.Net.NetworkInformation;
using System.Transactions;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace EAD_Assignment05
{
    public class EAD_Assignment05
    {
        static string conString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = AssignmentFive; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";
        SqlConnection con = new SqlConnection(conString);
        //--------------ReadEmployees Using SqlDataReader-----------------
        public void ReadEmployees()  
        { 
            
            con.Open();
            string query = "Select * from Employees";
            SqlCommand cmd= new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                Console.WriteLine($"Id: {dr[0]}   FirstName:  {dr[1]}   LastName: {dr[2]}   Email: {dr[3]}   PrimaryPhoneNumber: {dr[4]}   SecondaryPhoneNumber: {dr[5]}   CreatedBy: {dr[6]}   CreatedOn: {dr[7]}   ModifiedBy: {dr[8]}   ModifiedOn: {dr[9]}");
            }
            con.Close();
        }
        //------------------InsertEmployee Using SqlDataReader---------------------
        public void InsertEmployee()
        {
            Console.Write("Enter First name: ");
            string fname;
            do
            {
                fname = Console.ReadLine();
            } while (fname == "");
            Console.Write("Enter Last name: ");
            string lname;
            do
            {
                lname = Console.ReadLine();
            } while (lname == "");
            Console.Write("Enter Email: ");
            string email;
            do
            {
                email = Console.ReadLine();
            } while (email == "");
            Console.Write("Enter Primary Phone number: ");
            string p_phno;
            do
            {
                p_phno = Console.ReadLine();
                if (p_phno.Length > 11)
                {
                    Console.WriteLine("Length of Primary Phone Number is greater than 11 characters.Enter again!");
                }
            } while (p_phno == ""|| p_phno.Length>11);
            Console.Write("Enter Secondary Phone number: ");
            string? s_phno;
            do
            {
                s_phno = Console.ReadLine();
                if(s_phno.Length>11)
                {
                    Console.WriteLine("Length of Secondary Phone Number is greater than 11 character.Enter again!");
                }
            } while (s_phno.Length > 11);
            Console.Write("Created by: ");
            string createdby;
            do
            {
                createdby = Console.ReadLine();
            } while (createdby == "");
            Console.Write("Modified by: ");
            string? modifiedby = Console.ReadLine();
            DateTime createdon = DateTime.Now;
            DateTime? modifiedon;

            if (modifiedby != "") 
            {
                modifiedon = DateTime.Now;
                
            }
            else
            {
                modifiedon = null;
            }
            
            con.Open();
            string insertQuery = $"INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber,SecondaryPhoneNumber, CreatedBy, CreatedOn,ModifiedBy,ModifiedOn) VALUES ('{fname}', '{lname}', '{email}', '{p_phno}', '{s_phno}','{createdby}','{createdon}','{modifiedby}','{modifiedon}')";
            SqlCommand cmd= new SqlCommand(insertQuery, con);  
            int insertedRows= cmd.ExecuteNonQuery();
            if(insertedRows>=1)
            {
                Console.WriteLine("Record inserted successfully!");
            }
            con.Close();
        }
        //-------------------DeleteEmployee Using SqlDataReader--------------------------
        public void DeleteEmployee()
        {
            Console.Write("Enter Employee Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            
            con.Open();
            string delQuery=$"delete from Employees where Id='{id}'";
            SqlCommand cmd= new SqlCommand(delQuery, con);
            int delRows= cmd.ExecuteNonQuery();
            if (delRows >= 1)
            {
                Console.WriteLine("Record deleted successfully!");
            }
            con.Close();
        }
        //------------------SearchEmployee Using SqlDataReader-------------------------
        public void SearchEmployee()
        {

            Console.Write("Enter Employee Id to search: ");
            int id = int.Parse(Console.ReadLine());
           
            con.Open();
            string delQuery = $"select * from Employees where Id='{id}'";
            SqlCommand cmd = new SqlCommand(delQuery, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                Console.WriteLine($"Id: {reader[0]}   FirstName: {reader[1]}   LastName: {reader[2]}   Email: {reader[3]}   PrimaryPhoneNumber: {reader[4]}   SecondaryPhoneNumber: {reader[5]}   CreatedBy: {reader[6]}   CreatedOn: {reader[7]}   ModifiedBy: {reader[8]}   ModifiedOn: {reader[9]}");
            }
        }
        //--------------------UpdateEmployee Using SqlDataReader----------------------------
        public void UpdateEmployee()
        {
            int id;
            Console.Write("Enter driver ID to be updated : ");
            id = int.Parse(Console.ReadLine());

            Console.Write("Enter First name: ");
            string fname = Console.ReadLine();
            
            Console.Write("Enter Last name: ");
            string lname = Console.ReadLine();
            
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
           
            Console.Write("Enter Primary Phone number: ");
            string p_phno;
            do
            {
                p_phno = Console.ReadLine();
                if (p_phno.Length > 11)
                {
                    Console.WriteLine("Length of Primary Phone Number is greater than 11 characters.Enter again!");
                }
            } while (p_phno.Length > 11);
            Console.Write("Enter Secondary Phone number: ");
            string? s_phno;
            do
            {
                s_phno = Console.ReadLine();
                if (s_phno.Length > 11)
                {
                    Console.WriteLine("Length of Secondary Phone Number is greater than 11 character.Enter again!");
                }
            } while (s_phno.Length > 11);
            Console.Write("Created by: ");
            string createdby = Console.ReadLine();
            
            Console.Write("Modified by: ");
            string? modifiedby = Console.ReadLine();
            DateTime createdon = DateTime.Now;

            con.Open();
            string query = "";
            int updatedRows=0;
            if (fname != "")
            {
                query = $"update Employees set FirstName='{fname}' where Id='{id}'";
                SqlCommand cmd = new SqlCommand(query, con);
                updatedRows = cmd.ExecuteNonQuery();
            }
            if (lname != "")
            {
                query = $"update Employees set LastName='{lname}' where Id='{id}'";
                SqlCommand cmd = new SqlCommand(query, con);
                updatedRows = cmd.ExecuteNonQuery();
            }
            if (email != "")
            {
                query = $"update Employees set Email='{email}' where Id='{id}'";
                SqlCommand cmd = new SqlCommand(query, con);
                updatedRows = cmd.ExecuteNonQuery();
            }
            if (p_phno != "")
            {
                query = $"update Employees set PrimaryPhoneNumber='{p_phno}' where Id='{id}'";
                SqlCommand cmd = new SqlCommand(query, con);
                updatedRows = cmd.ExecuteNonQuery();
            }
            if (s_phno != "")
            {
                query = $"update Employees set SecondaryPhoneNumber='{s_phno}' where Id='{id}'";
                SqlCommand cmd = new SqlCommand(query, con);
                updatedRows = cmd.ExecuteNonQuery();
            }
            if (createdby != "")
            {
                query = $"update Employees set CreatedBy='{createdby}',CreatedOn='{DateTime.Now}' where Id='{id}'";
                SqlCommand cmd = new SqlCommand(query, con);
                updatedRows = cmd.ExecuteNonQuery();
            }
            
            if (modifiedby != "")
            {
                query = $"update Employees set ModifiedBy='{modifiedby}',ModifiedOn='{DateTime.Now}' where Id='{id}'";
                SqlCommand cmd = new SqlCommand(query, con);
                updatedRows = cmd.ExecuteNonQuery();
            }
           

            if (updatedRows >= 1)
            {
                Console.WriteLine("Record updated Successfully!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }

            con.Close();
        }
        //#################################################################
        //-----------------ReadEmployees Using SqlDataAddapter-------------
       public void ReadEmployeesUsingSqlDataAdapter()
       {
             con.Open();
             string query = "SELECT * FROM Employees";
             SqlDataAdapter adapter = new SqlDataAdapter(query, con);
             DataSet dataSet = new DataSet();
             adapter.Fill(dataSet, "Employees");

             DataTable table = dataSet.Tables["Employees"];

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"Id: {row["Id"]}   FirstName: {row["FirstName"]}   LastName: {row["LastName"]}   Email: {row["Email"]}   PrimaryPhoneNumber: {row["PrimaryPhoneNumber"]}   SecondaryPhoneNumber: {row["SecondaryPhoneNumber"]}   CreatedBy: {row["CreatedBy"]}   CreatedOn: {row["CreatedOn"]}   ModifiedBy: {row["ModifiedBy"]}   ModifiedOn: {row["ModifiedOn"]}");
            }
            con.Close();
        }
        //------------------InsertEmployee Using SqlDataAdapter-----------------
        public void InsertEmployeeUsingSqlDataAdapter()
        {

            Console.Write("Enter First name: ");
            string fname;
            do
            {
                fname = Console.ReadLine();
            } while (fname == "");
            Console.Write("Enter Last name: ");
            string lname;
            do
            {
                lname = Console.ReadLine();
            } while (lname == "");
            Console.Write("Enter Email: ");
            string email;
            do
            {
                email = Console.ReadLine();
            } while (email == "");
            Console.Write("Enter Primary Phone number: ");
            string p_phno;
            do
            {
                p_phno = Console.ReadLine();
                if (p_phno.Length > 11)
                {
                    Console.WriteLine("Length of Primary Phone Number is greater than 11 characters.Enter again!");
                }
            } while (p_phno == "" || p_phno.Length > 11);
            Console.Write("Enter Secondary Phone number: ");
            string? s_phno;
            do
            {
                s_phno = Console.ReadLine();
                if (s_phno.Length > 11)
                {
                    Console.WriteLine("Length of Secondary Phone Number is greater than 11 character.Enter again!");
                }
            } while (s_phno.Length > 11);
            Console.Write("Created by: ");
            string createdby;
            do
            {
                createdby = Console.ReadLine();
            } while (createdby == "");
            Console.Write("Modified by: ");
            string? modifiedby = Console.ReadLine();
            DateTime createdon = DateTime.Now;
            DateTime? modifiedon;

            if (modifiedby != "")
            {
                modifiedon = DateTime.Now;

            }
            else
            {
                modifiedon = null;
            }

            con.Open();
 
            string query = "INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber,SecondaryPhoneNumber, CreatedBy, CreatedOn,ModifiedBy,ModifiedOn) " +
                           "VALUES (@fname, @lname, @email, @p_phno, @s_phno, @createdby, @createdon, @modifiedby, @modifiedon)";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand(query, con);
            adapter.InsertCommand.Parameters.AddWithValue("@FirstName", fname);
            adapter.InsertCommand.Parameters.AddWithValue("@LastName", lname);
            adapter.InsertCommand.Parameters.AddWithValue("@Email", email);
            adapter.InsertCommand.Parameters.AddWithValue("@PrimaryPhoneNumber", p_phno);
            adapter.InsertCommand.Parameters.AddWithValue("@SecondartPhoneNumber", s_phno);
            adapter.InsertCommand.Parameters.AddWithValue("@CreatedBy", createdby);
            adapter.InsertCommand.Parameters.AddWithValue("@CreatedOn", createdon);
            adapter.InsertCommand.Parameters.AddWithValue("@ModifiedBy", modifiedby);
            adapter.InsertCommand.Parameters.AddWithValue("@ModifiedOn", modifiedon);

            int rowsAffected = adapter.InsertCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Record inserted Successfully!");
            }
            else
            {
                Console.WriteLine("Record inserted Failed!");
            }

            con.Close();
        }
        //------------------DeleteEmployee Using SqlDataAdapter-----------------
        public void DeleteEmployeeUsingSqlDataAdapter()
        {
            Console.Write("Enter Employee Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            con.Open();
            string query = "DELETE FROM Employees WHERE ID = @EmployeeID";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.DeleteCommand = new SqlCommand(query, con);
            adapter.DeleteCommand.Parameters.AddWithValue("@EmployeeID", id);

            int rowsAffected = adapter.DeleteCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Record deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Record deletion Failed!");
            }
            con.Close();
        }

        //------------------SearchEmployee Using SqlDataAdapter-----------------
        public void SearchEmployeeUsingSqlDataAdapter()
        {
            Console.Write("Enter Employee Id to Search: ");
            int id = int.Parse(Console.ReadLine());
            con.Open();
            string query = $"SELECT * FROM Employees WHERE Id = {id}";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Employees");

            DataTable table = dataSet.Tables["Employees"];

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"Id: {row["Id"]}   FirstName: {row["FirstName"]}   LastName: {row["LastName"]}   Email: {row["Email"]}   PrimaryPhoneNumber: {row["PrimaryPhoneNumber"]}   SecondaryPhoneNumber: {row["SecondaryPhoneNumber"]}   CreatedBy: {row["CreatedBy"]}   CreatedOn: {row["CreatedOn"]}   ModifiedBy: {row["ModifiedBy"]}   ModifiedOn: {row["ModifiedOn"]}");
            }
            con.Close();
        }
        //------------------UpdateEmployee Using SqlDataAdapter-----------------
        public void UpdateEmployeeUsingSqlDataAdapter()
        {

            int id;
            Console.Write("Enter driver ID to be updated : ");
            id = int.Parse(Console.ReadLine());

            Console.Write("Enter First name: ");
            string fname = Console.ReadLine();

            Console.Write("Enter Last name: ");
            string lname = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Primary Phone number: ");
            string p_phno;
            do
            {
                p_phno = Console.ReadLine();
                if (p_phno.Length > 11)
                {
                    Console.WriteLine("Length of Primary Phone Number is greater than 11 characters.Enter again!");
                }
            } while (p_phno.Length > 11);
            Console.Write("Enter Secondary Phone number: ");
            string? s_phno;
            do
            {
                s_phno = Console.ReadLine();
                if (s_phno.Length > 11)
                {
                    Console.WriteLine("Length of Secondary Phone Number is greater than 11 character.Enter again!");
                }
            } while (s_phno.Length > 11);
            Console.Write("Created by: ");
            string createdby = Console.ReadLine();

            Console.Write("Modified by: ");
            string? modifiedby = Console.ReadLine();
            DateTime createdon = DateTime.Now;

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            string query = "";
            int rowsAffected = 0;
            if (fname != "")
            {
                query = $"update Employees set FirstName='{fname}' where Id='{id}'";
                adapter.UpdateCommand = new SqlCommand(query, con);
                adapter.UpdateCommand.Parameters.AddWithValue("@FirstName", fname);
                 rowsAffected = adapter.UpdateCommand.ExecuteNonQuery();
            }
            if (lname != "")
            {
                query = $"update Employees set LastName='{lname}' where Id='{id}'";
                adapter.UpdateCommand = new SqlCommand(query, con);
                adapter.UpdateCommand.Parameters.AddWithValue("@LastName", lname);
                 rowsAffected = adapter.UpdateCommand.ExecuteNonQuery();
            }
            if (email != "")
            {
                query = $"update Employees set Email='{email}' where Id='{id}'";
                adapter.UpdateCommand = new SqlCommand(query, con);
                adapter.UpdateCommand.Parameters.AddWithValue("@Email", email);
                rowsAffected = adapter.UpdateCommand.ExecuteNonQuery();
            }
            if (p_phno != "")
            {
                query = $"update Employees set PrimaryPhoneNumber='{p_phno}' where Id='{id}'";
                adapter.UpdateCommand = new SqlCommand(query, con);
                adapter.UpdateCommand.Parameters.AddWithValue("@PrimaryPhoneNumber", p_phno);
                rowsAffected = adapter.UpdateCommand.ExecuteNonQuery();
            }
            if (s_phno != "")
            {
                query = $"update Employees set SecondaryPhoneNumber='{s_phno}' where Id='{id}'";
                adapter.UpdateCommand = new SqlCommand(query, con);
                adapter.UpdateCommand.Parameters.AddWithValue("@SecondaryPhoneNumber", s_phno);
                rowsAffected = adapter.UpdateCommand.ExecuteNonQuery();
            }
            if (createdby != "")
            {
                query = $"update Employees set CreatedBy='{createdby}',CreatedOn='{DateTime.Now}' where Id='{id}'";
                adapter.UpdateCommand = new SqlCommand(query, con);
                adapter.UpdateCommand.Parameters.AddWithValue("@CreatedBy", createdby);
                adapter.UpdateCommand.Parameters.AddWithValue("@CreatedOn", createdon);
                 rowsAffected = adapter.UpdateCommand.ExecuteNonQuery();
            }

            if (modifiedby != "")
            {
                query = $"update Employees set ModifiedBy='{modifiedby}',ModifiedOn='{DateTime.Now}' where Id='{id}'";
                adapter.UpdateCommand = new SqlCommand(query, con);
                adapter.UpdateCommand.Parameters.AddWithValue("@ModifiedBy", modifiedby);
                 rowsAffected = adapter.UpdateCommand.ExecuteNonQuery();
            }


            if (rowsAffected >= 1)
            {
                Console.WriteLine("Record updated Successfully!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }

            con.Close();
        }
    //####################################################################
        public static void Main(string[] args)
        {
            EAD_Assignment05 task = new EAD_Assignment05();
            do
            {
                Console.WriteLine("1. SqlDataReader");
                Console.WriteLine("2. SqlDataAdapter");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                int selection = int.Parse(Console.ReadLine());
                if (selection == 1)
                {
                    while (true)
                    {

                        Console.WriteLine("Employee Database");
                        Console.WriteLine("1. Read Employees");
                        Console.WriteLine("2. Insert Employee");
                        Console.WriteLine("3. Delete Employee");
                        Console.WriteLine("4. Search Employee");
                        Console.WriteLine("5. Update Employee");
                        Console.WriteLine("6. Exit");


                        Console.Write("Enter your choice: ");
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                task.ReadEmployees();
                                break;
                            case 2:
                                task.InsertEmployee();
                                break;
                            case 3:
                                task.DeleteEmployee();
                                break;
                            case 4:
                                task.SearchEmployee();
                                break;
                            case 5:
                                task.UpdateEmployee();
                                break;
                            case 6:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }

                    }
                }
                else if (selection == 2)
                {
                    while (true)
                    {

                        Console.WriteLine("Employee Database");
                        Console.WriteLine("1. Read Employees");
                        Console.WriteLine("2. Insert Employee");
                        Console.WriteLine("3. Delete Employee");
                        Console.WriteLine("4. Search Employee");
                        Console.WriteLine("5. Update Employee");
                        Console.WriteLine("6. Exit");


                        Console.Write("Enter your choice: ");
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                task.ReadEmployeesUsingSqlDataAdapter();
                                break;
                            case 2:
                                task.InsertEmployeeUsingSqlDataAdapter();
                                break;
                            case 3:
                                task.DeleteEmployeeUsingSqlDataAdapter();
                                break;
                            case 4:
                                task.SearchEmployeeUsingSqlDataAdapter();
                                break;
                            case 5:
                                task.UpdateEmployeeUsingSqlDataAdapter();
                                break;
                            case 6:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }

                    }
                }
                else if (selection == 3)
                {
                    Environment.Exit(0);
                }
            } while (true);
            
        }
    }
}