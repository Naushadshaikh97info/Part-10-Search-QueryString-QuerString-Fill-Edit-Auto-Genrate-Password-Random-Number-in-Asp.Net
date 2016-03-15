using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Studant_Deatils : System.Web.UI.Page
{
    DataClassesDataContext lnq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_class();
        fill_section();
        fill_data1();

        if(Request.QueryString["id"] !=null && Request.QueryString["id2"] !=null && Request.QueryString["id"] !=null)
        {
            fill_data();
        }
       
    }
    private void fill_class()
    {
        var id = (from a in lnq_obj.class_msts
                  select a).ToList();
        ddl_class.DataSource = id;
        ddl_class.DataBind();
        ddl_class.Items.Insert(0, "----Select----");
    }
    private void fill_section()
    {
        var id = (from a in lnq_obj.section_msts
                  select a).ToList();
        ddl_section.DataSource = id;
        ddl_section.DataBind();
        ddl_section.Items.Insert(0, "----Select---");
    }
    private void fill_data1()
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
    private void fill_data()
    {
        var id = (from a in lnq_obj.registraion_msts
                  join b in lnq_obj.class_msts on a.class_id equals b.intglcode
                  join c in lnq_obj.section_msts on a.section_id equals c.intglcode
                  where a.firstname == Request.QueryString["id"].ToString() && a.class_id == Convert.ToInt32(Request.QueryString["id2"].ToString()) && a.section_id== Convert.ToInt32(Request.QueryString["id3"].ToString())
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
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Studant Deatils.aspx?id=" + txt_name.Text + "&&" + "id2=" + ddl_class.SelectedValue + "&&" + "id3=" + ddl_section.SelectedValue);
        }
        
        catch(Exception ex)
        {

        }
    }
    protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_section();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int code = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value.ToString());
        Response.Redirect("Registraion.aspx?id=" + code);
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registraion.aspx");
    }
}