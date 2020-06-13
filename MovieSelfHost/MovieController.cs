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
                    Tags = (string)lcResult.Rows[0]["Tags"]
                };
            else
                return null;
        }

        public string PutGenre(clsGenre prGenre)
        {   // update
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                "UPDATE Genre SET " +
                "Tags = @Tags, " +
                "WHERE Name = @Name",
                    prepareGenreParameters(prGenre));
                if (lcRecCount == 1)
                    return "One Genre updated";
                else
                    return "Unexpected genre update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PostGenre(clsGenre prGenre)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                "INSERT INTO Artist VALUES (" +
                "@Name, " +
                "@Tags, ",
                prepareGenreParameters(prGenre));
                if (lcRecCount == 1)
                    return "One Genre added";
                else
                    return "Unexpected genre addition count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareGenreParameters(clsGenre prGenre)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(3);
            par.Add("Name", prGenre.Name);
            par.Add("Tags", prGenre.Tags);
            return par;
        }
    }
}

