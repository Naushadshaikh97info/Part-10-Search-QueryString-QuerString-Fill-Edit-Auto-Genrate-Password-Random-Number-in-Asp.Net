using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registraion : System.Web.UI.Page
{
    DataClassesDataContext lnq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_class();
        fill_data();

        if (Session["username"] != null)
        {
            if (Request.QueryString["id"].ToString() != null)
            {
                fill_datat();
            }
        }
        //Random rnd = new Random();
        //int startNumber = rnd.Next(1, 9000);
        //lbl_invoiceno.Text = startNumber.ToString();
    }
    private void fill_class()
    {
        var id = (from a in lnq_obj.class_msts
                  select a).ToList();
        ddl_class.DataSource=id;
        ddl_class.DataBind();
        ddl_class.Items.Insert(0,"------Select-----");
    }
    private void fill_section()
    {
        var id = (from a in lnq_obj.section_msts
                  where a.class_id == Convert.ToInt32(ddl_class.SelectedValue)
                  select a).ToList();
        ddl_section.DataSource=id;
        ddl_section.DataBind();
        ddl_section.Items.Insert(0,"-----Select------");
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        string strPwdchar = "abcdefghijklmnopqrstuvwxyz0123456789#+@&$ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string strPwd = "";
        Random rnd = new Random();
        for (int i = 0; i <= 7; i++)
        {
            int iRandom = rnd.Next(0, strPwdchar.Length - 1);
            strPwd += strPwdchar.Substring(iRandom, 1);
        }


        lnq_obj.insert_registraion(txt_firstname.Text, txt_lastname.Text, txt_username.Text, strPwd,Convert.ToInt32(ddl_class.SelectedValue),Convert.ToInt32(ddl_section.SelectedValue), txt_mobileno.Text, txt_emailid.Text);
        lnq_obj.SubmitChanges();
        fill_data();
    }
    private void fill_data()
    {
        var id = (from a in lnq_obj.registraion_msts
                  join b in lnq_obj.class_msts on a.class_id equals b.intglcode
                  join c in lnq_obj.section_msts on a.section_id equals c.intglcode
                  select new
                  {
                      code = a.intglcode,
                      firstname = a.firstname,
                      lastname = a.lastname,
                      username = a.username,
                      password = a.password,
                      class_id = b.@class,
                      section_id = c.section,
                      mobileno = a.mobileno,
                      emailid = a.emailid
                  }).ToList();
        GridView1.DataSource = id;
        GridView1.DataBind();
    }
    protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_section();
    }

    private void fill_datat()
    {
        var id = (from a in lnq_obj.registraion_msts
                  where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                  select a).Single();


        txt_firstname.Text = id.firstname;
        txt_lastname.Text = id.lastname;
        txt_username.Text = id.username;
        txt_password.Text = id.password;
        txt_mobileno.Text = id.mobileno;
        txt_emailid.Text = id.emailid;
    }
}