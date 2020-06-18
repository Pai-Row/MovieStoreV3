using System;
using System.Collections.Generic;
using System.Data;

namespace MovieSelfHost
{
    public class MovieController : System.Web.Http.ApiController
    {
        public List<string> GetGenreNames()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT Name FROM Genre", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }


        public clsGenre GetGenre(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult =
                    clsDbConnection.GetDataTable("SELECT * FROM Genre WHERE Name = @Name", par);
            if (lcResult.Rows.Count > 0)
                return new clsGenre()
                {
                    GenreID = (int)lcResult.Rows[0]["GenreID"],
                    Name = (string)lcResult.Rows[0]["Name"],
                    Tags = (string)lcResult.Rows[0]["Tags"],
                    MovieList = getGenreMovie((int)lcResult.Rows[0]["GenreID"])
                };
            else
                return null;
        }

        private List<clsAllMovie> getGenreMovie(int ID)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("ID", ID);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Movie WHERE GenreID = @ID", par);
            List<clsAllMovie> lcWorks = new List<clsAllMovie>();
            foreach (DataRow dr in lcResult.Rows)
                lcWorks.Add(dataRow2AllMovie(dr));
            return lcWorks;
        }

        public List<string> GetMovieTitles(string Title, bool Rentable)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(2);
            par.Add("Title", Title);
            par.Add("Rentable", Rentable);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT Title FROM Movie WHERE Title = @Title AND Rentable = @Rentable", par);
            List<string> lcTitle = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcTitle.Add((string)dr[0]);
            return lcTitle;
        }

        private clsAllMovie dataRow2AllMovie(DataRow dr)
        {
            return new clsAllMovie()
            {
                MovieID = Convert.ToInt16(dr["MovieID"]),
                GenreID = Convert.ToInt16(dr["GenreID"]),
                Title = Convert.ToString(dr["Title"]),
                Price = Convert.ToInt16(dr["Price"]),
                DateTimeModified = Convert.ToDateTime(dr["DateTimeModified"]),
                Available = Convert.ToBoolean(dr["Available"]),
                ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]),
                Rentable = Convert.ToBoolean(dr["Rentable"]),
                ReturnDate = Convert.ToDateTime(dr["ReturnDate"]),
                Discount = Convert.ToInt16(dr["Discount"]),
            };
    
        }

        public string PostMovie(clsAllMovie prMovie)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO Movie " +
                "(GenreID, Title, Price, DateTimeModified, ReleaseDate, Rentable, ReturnDate, Available, Discount) " +
                "VALUES (@GenreID, @Title, @Price, @DateTimeModified, @ReleaseDate, @Rentable, @ReturnDate, @Available, @Discount)",
                prepareMovieParameters(prMovie));
                if (lcRecCount == 1)
                    return "New Movie record created";
                else
                    return "Unexpected movie creation count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PutMovie(clsAllMovie prMovie)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute(
               "UPDATE Movie SET GenreID = @GenreID, Title = @Title, Price = @Price, DateTimeModified = @DateTimeModified," +
               "ReleaseDate = @ReleaseDate, Rentable = @Rentable, ReturnDate = @ReturnDate, Available = @Available," + 
               "Discount = @Discount WHERE MovieID = @MovieID",
               prepareMovieParameters(prMovie));
                if (lcRecCount == 1)
                    return "Movie details updated";
                else
                    return "Unexpected movie update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteMovie(int MovieID)
        {
            try
            {
                Dictionary<string, object> par = new Dictionary<string, object>(1);
                par.Add("ID", MovieID);
                int lcRecCount = clsDbConnection.Execute(
                "DELETE FROM Movie WHERE MovieID = @ID", par);
                if (lcRecCount == 1)
                    return "Record removed";
                else
                    return "Unexpected movie removal count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareMovieParameters(clsAllMovie prMovie)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(9);
            par.Add("MovieID", prMovie.MovieID);
            par.Add("GenreID", prMovie.GenreID);
            par.Add("Title", prMovie.Title);
            par.Add("Price", prMovie.Price);
            par.Add("DateTimeModified", prMovie.DateTimeModified);
            par.Add("Available", prMovie.Available);
            par.Add("ReleaseDate", prMovie.ReleaseDate);
            par.Add("Rentable", prMovie.Rentable);
            par.Add("ReturnDate", prMovie.ReturnDate);
            par.Add("Discount", prMovie.Discount);
            return par;
        }

        private Dictionary<string, object> prepareOrderParameters(clsOrder prOrder)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(5);
            par.Add("MovieID", prOrder.MovieID);
            par.Add("Quantity", prOrder.Quantity);
            par.Add("Price", prOrder.Price);
            par.Add("Date", prOrder.Date);
            par.Add("CustomerName", prOrder.CustomerName);
            par.Add("CustomerAddress", prOrder.CustomerAddress);
            return par;
        }

        public List<clsOrder> GetOrdersList()
        {
            DataTable lcResult =
                    clsDbConnection.GetDataTable("SELECT * FROM [Order]", null);
            List<clsOrder> OrderList = new List<clsOrder>();
            if (lcResult.Rows.Count > 0)
            {
                for (int i = 0; i < lcResult.Rows.Count; i++)
                {
                    OrderList.Add(
                       new clsOrder()
                       {
                           OrderID = (int)lcResult.Rows[i]["OrderID"],
                           MovieID = (int)lcResult.Rows[i]["MovieID"],
                           Quantity = (int)lcResult.Rows[i]["Quantity"],
                           Price = (int)lcResult.Rows[i]["Price"],
                           Date = (DateTime)lcResult.Rows[i]["Date"],
                           CustomerName = (string)lcResult.Rows[i]["CustomerName"],
                           CustomerAddress = (string)lcResult.Rows[i]["CustomerAddress"]
                       }
                   );
                }
                return OrderList;
            }  
            else
                return null;
        }

        public clsOrder GetOrderDetails(int ID)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("ID", ID);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM [Order] WHERE OrderID = @ID", par);
            if (lcResult.Rows.Count > 0)
                return new clsOrder()
                {
                    OrderID = (int)lcResult.Rows[0]["OrderID"],
                    MovieID = (int)lcResult.Rows[0]["MovieID"],
                    Quantity = (int)lcResult.Rows[0]["Quantity"],
                    Price = (int)lcResult.Rows[0]["Price"],
                    Date = (DateTime)lcResult.Rows[0]["Date"],
                    CustomerName = (string)lcResult.Rows[0]["CustomerName"],
                    CustomerAddress = (string)lcResult.Rows[0]["CustomerAddress"]
                };
            else
                return null;
        }

        public List<double> GetTotalOrdersValue()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT OrderPrice FROM [Order]", null);
            List<double> lcPrice = new List<double>();
            foreach (DataRow dr in lcResult.Rows)
                lcPrice.Add((double)dr[0]);
            return lcPrice;
        }

        public string PostOrder(clsOrder prOrder)
        { // insert
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO [Order] (MovieID, Quantity, Price, Date, CustomerName, CustomerAddress)" +
                    " VALUES (@MovieID, @Quantity, @Price, @Date, @CustomerName, @CustomerAddress)", prepareOrderParameters(prOrder));
                if (lcRecCount == 1)
                    return "New order created";
                else
                    return "Unexpected order creation count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteOrder(int ID)
        { // Delete
            try
            {
                Dictionary<string, object> par = new Dictionary<string, object>(1);
                par.Add("ID", ID);
                int lcRecCount = clsDbConnection.Execute(
                "DELETE FROM [Order] WHERE OrderID = @ID;", par);
                if (lcRecCount == 1)
                    return "Order Removed";
                else
                    return "Unexpected order removal count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
    }
}

