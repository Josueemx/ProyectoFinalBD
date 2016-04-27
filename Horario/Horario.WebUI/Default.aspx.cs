using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Horario.WebUI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection())
                {
                    conn.ConnectionString = "data source=JOSUE;initial catalog=ProyectoFinalBD;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;"; //aqui ultimo ";"
                    using (System.Data.SqlClient.SqlCommand command = conn.CreateCommand())
                    {
                        conn.Open();
                        command.CommandText = "ProfesoresPagInicio";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        this.ProfeGrid.DataSource = command.ExecuteReader();
                        this.ProfeGrid.DataBind();
                        this.ProfeGrid2.DataSource = command.ExecuteReader(); // aqui ni idea si funciona
                        this.ProfeGrid2.DataBind(); // aqui ni idea si funciona
                        conn.Close();

                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

        }
    }
}