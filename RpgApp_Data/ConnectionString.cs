using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgApp_Model;
using System.Data.SqlClient;
using System.Data;

namespace RpgApp_Data
{
    class ConnectionString
    {
        public SqlConnection connectionString = new SqlConnection
        (
            @"Server=mssql.fhict.local;Database=dbi406383;User Id=dbi406383;Password=Appeltelers383;"
        );

        //public SqlConnection connectionString = new SqlConnection
        //(
        //    @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Gebruiker\Desktop\School\Visual Studio\ICT_Software\Semester 2\RpgApp\RpgApp\App_Data\RpgDB.mdf; Integrated Security = True;"
        //);
    }
}
