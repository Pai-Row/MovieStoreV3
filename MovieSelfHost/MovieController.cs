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
            return lcNames; }
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

}

