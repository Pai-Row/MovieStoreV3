using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MovieSelfHost
{
    class MovieController : System.Web.Http.ApiController
    {
    public List<string> GetGenreNames()
    { 
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT Name FROM Genre", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows) 
                lcNames.Add((string)dr[0]);
            return lcNames; }
    }
}
