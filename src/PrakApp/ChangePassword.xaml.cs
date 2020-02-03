using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PrakApp.Views
{
	/// <summary>
	/// Interaction logic for ChangePassword.xaml
	/// </summary>
	public partial class ChangePassword : MetroWindow
	{
		public ChangePassword(string userText)
		{
			InitializeComponent();
			lblUser.Text = userText;
		}

		private void btnChangePass_Click(object sender, RoutedEventArgs e)
		{
			string password = ConvertToUnsecureString(txtPassword.SecurePassword);
			string confirmPassword = ConvertToUnsecureString(txtConfirmPassword.SecurePassword);


			if (password == confirmPassword)
			{
				if (password == $"1{lblUser.Text}")
				{
					txtPassword.Password = "";
					txtConfirmPassword.Password = "";
					this.ShowMessageAsync("Error", "You cannot use the same password");

				}
				else if (password == "")
				{
					txtPassword.Password = "";
					txtConfirmPassword.Password = "";
					this.ShowMessageAsync("Error", "Password cannot be empty");
				}
				else if (password.Length < 5)
				{
					txtPassword.Password = "";
					txtConfirmPassword.Password = "";
					this.ShowMessageAsync("Error", "Password must have 5 or more characters");
				}
				else if (password.Contains(" "))
				{
					txtPassword.Password = "";
					txtConfirmPassword.Password = "";
					this.ShowMessageAsync("Error", "Password cannot have any spaces");
				}
				else if (confirmPassword != password)
				{
					txtPassword.Password = "";
					txtConfirmPassword.Password = "";
					this.ShowMessageAsync("Error", "The passwords do not match");
				}
				else
				{
					try
					{
						using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Users))
						{
							con.Open();
							string HashedPassword = BCrypt.Net.BCrypt.HashPassword(confirmPassword);
							using (SqlCommand cmd = new SqlCommand(@"UPDATE dbo.Users SET Password=@pass WHERE Username=@uname", con))
							{
								//insert username here
								cmd.Parameters.AddWithValue("@uname", lblUser.Text);
								cmd.Parameters.AddWithValue("@pass", HashedPassword);

								cmd.ExecuteNonQuery();
								Login login = new Login();
								this.ShowMessageAsync("Success", "Password has been changed!");
								Task.Delay(3000);
								this.Close();
								login.Show();

							}
						}
					}
					catch (Exception)
					{

					}
				}
			}
		}


		private string ConvertToUnsecureString(SecureString securePassword)
		{
			if (securePassword == null)
			{
				return string.Empty;
			}

			IntPtr unmanagedString = IntPtr.Zero;
			try
			{
				unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
				return Marshal.PtrToStringUni(unmanagedString);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
			}
		}
	}
}
