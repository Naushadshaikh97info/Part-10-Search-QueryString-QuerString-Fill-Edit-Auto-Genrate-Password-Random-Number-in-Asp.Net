using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Class : System.Web.UI.Page
{
    DataClassesDataContext lnq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
            return;
        fill_data();
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        lnq_obj.insert_class(txt_class.Text);
        lnq_obj.SubmitChanges();
        txt_class.Text = "";
        fill_data();
    }
    private void fill_data()
    {
        var id = (from a in lnq_obj.class_msts
                  select new
                  {
                      code = a.intglcode,
                      aclass = a.@class
                  }).ToList();
        GridView1.DataSource = id;
        GridView1.DataBind();
    }
}