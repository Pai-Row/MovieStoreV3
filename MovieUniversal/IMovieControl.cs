using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieUniversal
{
    interface IMovieControl
    {
        void PushData(clsAllMovie prMovie);
        void UpdateControl(clsAllMovie prMovie);
    }
}
