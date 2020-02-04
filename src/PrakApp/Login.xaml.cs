using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
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
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : MetroWindow
	{
		public Login()
		{
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			LoginApp();
		}
		private void LoginApp()
		{
			string Username = txtUsername.Text;
			try
			{
				using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Users))
				{
					con.Open();
					using (SqlCommand cmd2 = new SqlCommand(@"SELECT Password from dbo.Users WHERE Username=@uname", con))
					{
						cmd2.Parameters.AddWithValue("@uname", txtUsername.Text);
						var passworddb = (string)cmd2.ExecuteScalar();
						string password = ConvertToUnsecureString(txtPassword.SecurePassword);
						try
						{
							if (password == passworddb || passworddb == "1" + txtUsername.Text) //Check if the text  is equal to the plain text in the database and if so prompt to change password
							{
								txtPassword.Password = "";
								ChangePassword cp = new ChangePassword(txtUsername.Text);
								cp.Show();
								this.Hide();
							}
							else
							{
								bool validPassword = false;
								try
								{
									using (SqlCommand cmd3 = new SqlCommand(@"SELECT Password from dbo.Users WHERE Username=@uname", con))
									{
										cmd3.Parameters.AddWithValue("@uname", txtUsername.Text);
										var hashedPassword = (string)cmd3.ExecuteScalar();

										//Checks if password is valid with bCrypt and returns true or false
										validPassword = BCrypt.Net.BCrypt.Verify(password, hashedPassword);


										if (validPassword)	
										{
											MainWindow mw = new MainWindow();
											this.Close();
											mw.Show();

										}
										else
										{
											this.ShowMessageAsync("Incorrect Password", "Please try again");
										}
									}
								}
								catch (Exception)
								{

								}
							}

						}

						catch (Exception)
						{
							MessageBox.Show("Password was incorrect");
						}

					}
					//connection closed 
					con.Close();
				}
			}
			catch (Exception)
			{

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
