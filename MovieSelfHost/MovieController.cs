using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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

        private clsAllMovie dataRow2AllMovie(DataRow dr)
        {
            return new clsAllMovie()
            {
                MovieID = Convert.ToInt16(dr["MovieID"]),
                GenreID = Convert.ToInt16(dr["GenreID"]),
                Title = Convert.ToString(dr["Title"]),
                Price = Convert.ToInt16(dr["Price"]),
                DateTimeModified = Convert.ToDateTime(dr["DateTimeModified"]),
                Quantity = Convert.ToInt16(dr["Quantity"]),
                ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]),
                Rentable = Convert.ToBoolean(dr["Rentable"]),
                Discount = Convert.ToInt16(dr["Discount"]),
            };
    
    }   }
}

