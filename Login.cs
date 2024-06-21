﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Final_Proyect_CSharp
{
    public partial class Login : Form
    {
        // Propiedad estática para acceder a la instancia del formulario de inicio de sesión
        public static Login Instancia { get; private set; }

        public Login()
        {
            InitializeComponent();
            Instancia = this; // Asigna la instancia actual a la propiedad estática
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Consulta SQL para verificar las credenciales del usuario
            string query = @"
                SELECT CASE 
                    WHEN EXISTS (
                                 SELECT 1
                                 FROM Users
                                 WHERE NAME = @Name
                                 AND CONVERT(VARCHAR(50), DECRYPTBYPASSPHRASE('040329', PASSWORD_ENCRIPTADO)) = @Password
                             ) THEN 1
                    ELSE 0
                END AS CredencialesCorrectas";

            // Ejecutar la consulta SQL y obtener el resultado como un objeto
            object result = Connection.ExecuteScalar(query,
                new SqlParameter("@Name", txtName.Text),
                new SqlParameter("@Password", txtPassword.Text)
            );

            // Verificar si el resultado no es nulo y es convertible a un entero
            if (result != null && int.TryParse(result.ToString(), out int credencialesCorrectas))
            {
                // Verificar si las credenciales son correctas
                if (credencialesCorrectas == 1)
                {
                    // Las credenciales son correctas, puedes continuar con el resto del proceso
                    MessageBox.Show("Valid login credentials. Access granted.");
                    Form1 newUserInstance = new Form1();
                    newUserInstance.Visible = true;
                    this.Visible = false;
                    txtName.Clear();
                    txtPassword.Clear();
                }
                else
                {
                    // Las credenciales son incorrectas
                    MessageBox.Show("Incorrect username or password. Please try again.");

                }
            }
            else
            {
                // No se pudo obtener un resultado válido de la consulta
                MessageBox.Show("Error verifying credentials. Please try again.");

            }
        }
    }
}
}
