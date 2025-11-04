using Love_Compatibility;
using System;
using System.Web;

public partial class api : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string name1 = Request.Form["name1"];
            string name2 = Request.Form["name2"];

            if (!string.IsNullOrEmpty(name1) && !string.IsNullOrEmpty(name2))
            {
                CompatibilityCalculator calc = new CompatibilityCalculator();
                calc.Name1 = name1;
                calc.Name2 = name2;
                string result = calc.CalculateCompatibility();
                string[] parts = result.Split('|');
                string json = "{\"percentage\":" + parts[0] + ",\"message\":\"" + parts[1].Replace("\"", "\\\"") + "\"}";
                Response.ContentType = "application/json";
                Response.Write(json);
            }
            else
            {
                Response.Write("{\"error\":\"Missing inputs\"}");
            }
        }
        catch (Exception ex)
        {
            Response.Write("{\"error\":\"" + ex.Message + "\"}");
        }
        Response.End();
    }
}