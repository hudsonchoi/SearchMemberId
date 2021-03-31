using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchMemberId : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string message;
        try
        {

            int memberId = 0;
            using (SqlConnection con = new SqlConnection("Data Source=123.123.123.123,1507;Initial Catalog=v8_njchodae;User ID=v8_njchodae@ro21;Password=njc918ac97712@C!!@#"))
            {
                con.Open();

                using (SqlCommand cmdSelect = new SqlCommand("SELECT id FROM dbo.people WHERE name like '%" + tb_name.Text.Trim() + "%' AND birthDate = '" + tb_birth.Text + "' AND deleted is null", con))
                {
                    using (SqlDataReader reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                memberId = reader.GetInt32(i);
                            }
                        }
                    }
                }
            }
            if (memberId == 0)
            {
                message = string.Format("입력하신 교인은<br/> 찾을 수가 없습니다.");
            }
            else
            {
                message = string.Format("{0} 님의 교인번호는<br/> {1} 입니다.", tb_name.Text, memberId.ToString());
            }
            divfields.Visible = false;
            lblresult.Text = message;
            divresult.Visible = true;
            //StringBuilder sb = new StringBuilder();
            //sb.Append("<script>");
            //sb.Append("window.open('default2.aspx?Message=").Append(str).Append("', '','toolbar=1,scrollbars=1,location=1,statusbar=1,menubar=1,resizable=1,width=385,height=135');");
            //sb.Append("</scri");
            //sb.Append("pt>");

            //Page.RegisterStartupScript("test", sb.ToString());
        }
        catch
        {
            message = string.Format("입력하신 교인은<br/> 찾을 수가 없습니다.");
            string str = System.Web.HttpUtility.UrlEncode(message);
            divfields.Visible = false;
            lblresult.Text = message;
            divresult.Visible = true;

        }

    }
}