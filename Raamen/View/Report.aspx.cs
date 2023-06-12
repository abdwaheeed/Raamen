using Raamen.Dataset;
using Raamen.Handler;
using Raamen.Model.Database;
using Raamen.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] != null && Raamen.Controller.UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                TransactionReport report = new TransactionReport();
                CrystalReportViewer1.ReportSource = report;
                RaamenDataset data = getData(TransactionHandler.getTransactionHeader());
                report.SetDataSource(data);
            }
            else
            {
                Response.Redirect("~/View/Home.aspx");
            }
                


        }

        protected RaamenDataset getData(List<Header> transaction)
        {
            RaamenDataset data = new RaamenDataset();

            var header = data.Transaction;
            var detail = data.TransactionDetail;

            foreach (Header t in transaction)
            {
                var hrow = header.NewRow();
                hrow["Id"] = t.Id;
                hrow["CustomerId"] = t.CustomerId;
                hrow["StaffId"] = t.StaffId;
                hrow["Date"] = t.Date;
                header.Rows.Add(hrow);

                foreach(Detail d in t.Details)
                {
                    var drow = detail.NewRow();

                    drow["HeaderId"] = d.HeaderId;
                    drow["RamenId"] = d.RamenId;
                    drow["Quantity"] = d.Quantity;
                    detail.Rows.Add(drow);

                }
            }

            return data;
        }
    }
}