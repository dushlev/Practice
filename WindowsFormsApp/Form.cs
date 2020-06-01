using System;
using System.Linq;
using System.Windows.Forms;
using SharedProject;

namespace WindowsFormsApp
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            MessageBox.Show(
        "Enter the line with expression in the textBox and click the Read button.",
        "ReadMe");

        }
        string str = null, strFormatobj = null;

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                strFormatobj = textBoxInput.Text;
                FormatExpression obj = new FormatExpression();
                obj.str = strFormatobj;
                str = obj.FormatStr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
        ex.Message,
        "An exception has occurred");
            }

            try
            {
                string strResult = null;
                using (UserContext db = new UserContext())
                {
                    Expression exp1 = new Expression { ExpressionStr = str };
                    db.Expressions.Add(exp1);

                    db.SaveChanges();
                    var users = db.Expressions;


                    var lastResult = db.Expressions.OrderBy(b => b.Id)
.Skip(Math.Max(0, db.Expressions.OrderBy(b => b.Id).Count() - 5));
                    foreach (Expression exp in lastResult)
                    {
                        strResult += exp.Id.ToString() + ". " + exp.ExpressionStr + "\r\n";
                    }
                }
                textBoxOutput.Text = strResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
           ex.Message,
           "An exception has occurred");
            }
        }
    }
}