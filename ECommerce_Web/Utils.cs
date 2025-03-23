using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ECommerce_Web
{	
	public class Utils
	{
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter sda;
		SqlDataReader sdr;
		DataTable dt;

		public static string getConnection()
		{
			return ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
		}
		public static bool isValidExtension(string fileName)
		{
			bool isValid = false;
			string[] fileExtension = { ".jpg", ".png", ".jpeg" };
			foreach (string file in fileExtension)
			{
				if(fileName.Contains(file))
					{ isValid = true; break; }
			}
			return isValid;
		}

		public static string getUniqueId()
		{
			Guid guid = Guid.NewGuid();
			return guid.ToString();
		}
		public static string getImageUrl(Object url)
		{
			string ImageUrl = string.Empty;
			if(string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
			{
				ImageUrl = "../Images/No_image.png";

			}
			else
			{
				ImageUrl = string.Format("../{0}", url);
			}
			return ImageUrl;
		}
	}
}