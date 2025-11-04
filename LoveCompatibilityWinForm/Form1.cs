using Love_Compatibility;
using System;
using System.Windows.Forms;

namespace LoveCompatibilityWinForm
{
    public partial class Form1 : Form
    {
        private Label label1;
        private Label label2;
        private TextBox txtName1;
        private TextBox txtName2;
        private Button btnCalculate;
        private Label lblResult;
        private Label label3;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            // Lấy input từ textbox
            string name1 = txtName1.Text.Trim();
            string name2 = txtName2.Text.Trim();

            if (string.IsNullOrEmpty(name1) || string.IsNullOrEmpty(name2))
            {
                lblResult.Text = "Vui lòng nhập cả hai tên!";
                return;
            }

            // Tạo instance từ DLL và tính toán
            CompatibilityCalculator calc = new CompatibilityCalculator();
            calc.Name1 = name1;
            calc.Name2 = name2;
            string result = calc.CalculateCompatibility();

            // Phân tách kết quả (percentage|message)
            string[] parts = result.Split('|');
            int percentage = int.Parse(parts[0]);
            string message = parts[1];

            // Hiển thị kết quả với dấu ấn cá nhân
            lblResult.Text = "Theo LOVE COMPATIBILITY CALCULATOR:\n";
            lblResult.Text += $"Độ tương thích giữa {name1} và {name2}: {percentage}%\n";
            lblResult.Text += message;

            // Thêm hiệu ứng cá nhân: emoji bằng ký tự
            if (percentage > 90)
                lblResult.Text += "\n♥♥♥ Hai bạn là định mệnh! ♥♥♥";
            else if (percentage > 80)
                lblResult.Text += "\n♥♥ Tuyệt vời lắm! ♥♥";
            else if (percentage >= 50)
                lblResult.Text += "\n♥ Có tiềm năng đấy! ♥";
            else
                lblResult.Text += "\n☹ Cố lên nhé! ☹";
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName1 = new System.Windows.Forms.TextBox();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtName1
            // 
            resources.ApplyResources(this.txtName1, "txtName1");
            this.txtName1.Name = "txtName1";
            // 
            // txtName2
            // 
            resources.ApplyResources(this.txtName2, "txtName2");
            this.txtName2.Name = "txtName2";
            // 
            // btnCalculate
            // 
            resources.ApplyResources(this.btnCalculate, "btnCalculate");
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click_1);
            // 
            // lblResult
            // 
            resources.ApplyResources(this.lblResult, "lblResult");
            this.lblResult.Name = "lblResult";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtName2);
            this.Controls.Add(this.txtName1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}