using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObject;
using System.Data.SqlClient;
using System.Data;

namespace DataManager
{
    public class DBWorker
    {
        private string connectionString;
        
        private List<Car> cars = new List<Car>();

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        private List<Client> clients = new List<Client>();

        public List<Client> Clients
        {
            get { return clients; }
            set { clients = value; }
        }

        private List<Driver> drivers = new List<Driver>();

        public List<Driver> Drivers
        {
            get { return drivers; }
            set { drivers = value; }
        }

        private List<Route> routes = new List<Route>();

        public List<Route> Routes
        {
            get { return routes; }
            set { routes = value; }
        }

        public DBWorker(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        public void AddCar(string model, int idDriver, string free) 
        {
            using (SqlConnection con = new SqlConnection(connectionString)) 
            {
                try
                {
                    string query = "INSERT INTO Car (model, driver_id, free) VALUES ("
                        + "'" + model + "'" + "," + idDriver + "," + "'" + free + "'" + ")";
                    SqlCommand cmnd = new SqlCommand(query, con);
                    cmnd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void AddClient(string name, string phone)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO Client (name, phone) VALUES ("
                        + "'" + name + "'" + "," + "'" + phone + "'" + ")";
                    SqlCommand cmnd = new SqlCommand(query, con);
                    cmnd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void AddDriver(string firstname, string lastname, string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO Driver (firstname, lastname, email) VALUES ("
                        + "'" + firstname + "'" + "," + "'" + lastname + "'" + "," + "'" + email + "'" + ")";
                    SqlCommand cmnd = new SqlCommand(query, con);
                    cmnd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void AddRoute(string pointA, string pointB, float distance)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO Route (pointA, pointB, distance) VALUES ("
                        + "'" + pointA + "'" + "," + "'" + pointB + "'" + "," + distance + ")";
                    SqlCommand cmnd = new SqlCommand(query, con);
                    cmnd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void EditCar(string model, int idDriver, string free, int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE Car SET model = " + "'" + model + "'" +
                        "," + "idDriver = " + idDriver + "," + "free=" + "'" + free + "'" +
                        "WHERE id=" + id;
                    SqlCommand cmnd = new SqlCommand(query, con);
                    cmnd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void EditClient(string name, string phone, int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE Client SET name = " + "'" + name + "'" +
                        "," + "phone=" + "'" + phone + "'" +
                        "WHERE id=" + id;
                    SqlCommand cmnd = new SqlCommand(query, con);
                    cmnd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void EditDriver(string firstname, string lastname, string email, int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE Driver SET firstname = " + "'" + firstname + "'" +
                        "," + "lastname=" + "'" + lastname + "'" +
                        "," + "email=" + "'" + email + "'" + 
                        "WHERE id=" + id;
                    SqlCommand cmnd = new SqlCommand(query, con);
                    cmnd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void EditRoute(string pointA, string pointB, float distance, int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE Driver SET pointA = " + "'" + pointA + "'" +
                        "," + "pointB=" + "'" + pointB + "'" +
                        "," + "distance=" +  distance + 
                        "WHERE id=" + id;
                    SqlCommand cmnd = new SqlCommand(query, con);
                    cmnd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void DeleteCar(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM Car WHERE id = " + id;
                    SqlCommand cmnd = new SqlCommand(query, con);
                    cmnd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void DeleteClient(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM Client WHERE id = " + id;
                    SqlCommand cmnd = new SqlCommand(query, con);
                    cmnd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void DeleteDriver(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM Driver WHERE id = " + id;
                    SqlCommand cmnd = new SqlCommand(query, con);
                    cmnd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void DeleteRoute(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM Route WHERE id = " + id;
                    SqlCommand cmnd = new SqlCommand(query, con);
                    cmnd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void SelectCars()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Car";
                    SqlCommand cmnd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmnd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows) 
                    {
                        Car car = new Car();
                        car.Model = row["model"].ToString();
                        car.IsFree = row["free"].ToString();
                        Cars.Add(car);
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

        public void SelectClients()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Client";
                    SqlCommand cmnd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmnd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Client client = new Client();
                        client.Name = row["name"].ToString();
                        client.Phone = row["phone"].ToString();
                        Clients.Add(client);
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

        public void SelectDrivers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Driver";
                    SqlCommand cmnd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmnd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Driver driver = new Driver();
                        driver.FirstName = row["firstname"].ToString();
                        driver.LastName = row["lastname"].ToString();
                        driver.Email = row["email"].ToString();
                        Drivers.Add(driver);
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

        public void SelectRoutes()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Route";
                    SqlCommand cmnd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmnd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Route route = new Route();
                        route.PointA = row["pointA"].ToString();
                        route.PointB = row["pointB"].ToString();
                        route.Distance = (float)row["distance"];
                        Routes.Add(route);
                    }
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
