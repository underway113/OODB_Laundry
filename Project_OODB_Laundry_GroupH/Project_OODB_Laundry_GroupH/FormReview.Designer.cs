namespace Project_OODB_Laundry_GroupH
{
    partial class FormReview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxProduct = new System.Windows.Forms.GroupBox();
            this.groupBoxReview = new System.Windows.Forms.GroupBox();
            this.groupBoxNewReview = new System.Windows.Forms.GroupBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.richTextBoxContentNewReview = new System.Windows.Forms.RichTextBox();
            this.textBoxReviewID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxNewReview.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(222, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Review";
            // 
            // groupBoxProduct
            // 
            this.groupBoxProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProduct.Location = new System.Drawing.Point(23, 36);
            this.groupBoxProduct.Name = "groupBoxProduct";
            this.groupBoxProduct.Size = new System.Drawing.Size(489, 169);
            this.groupBoxProduct.TabIndex = 1;
            this.groupBoxProduct.TabStop = false;
            this.groupBoxProduct.Text = "Product";
            // 
            // groupBoxReview
            // 
            this.groupBoxReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxReview.Location = new System.Drawing.Point(17, 211);
            this.groupBoxReview.Name = "groupBoxReview";
            this.groupBoxReview.Size = new System.Drawing.Size(495, 162);
            this.groupBoxReview.TabIndex = 1;
            this.groupBoxReview.TabStop = false;
            this.groupBoxReview.Text = "Review";
            // 
            // groupBoxNewReview
            // 
            this.groupBoxNewReview.Controls.Add(this.buttonAdd);
            this.groupBoxNewReview.Controls.Add(this.richTextBoxContentNewReview);
            this.groupBoxNewReview.Controls.Add(this.textBoxReviewID);
            this.groupBoxNewReview.Controls.Add(this.label2);
            this.groupBoxNewReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNewReview.Location = new System.Drawing.Point(12, 379);
            this.groupBoxNewReview.Name = "groupBoxNewReview";
            this.groupBoxNewReview.Size = new System.Drawing.Size(500, 188);
            this.groupBoxNewReview.TabIndex = 1;
            this.groupBoxNewReview.TabStop = false;
            this.groupBoxNewReview.Text = "New Review";
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.DarkTurquoise;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(410, 146);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(84, 36);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            // 
            // richTextBoxContentNewReview
            // 
            this.richTextBoxContentNewReview.Location = new System.Drawing.Point(11, 55);
            this.richTextBoxContentNewReview.Name = "richTextBoxContentNewReview";
            this.richTextBoxContentNewReview.Size = new System.Drawing.Size(477, 85);
            this.richTextBoxContentNewReview.TabIndex = 2;
            this.richTextBoxContentNewReview.Text = "";
            // 
            // textBoxReviewID
            // 
            this.textBoxReviewID.Location = new System.Drawing.Point(166, 25);
            this.textBoxReviewID.Name = "textBoxReviewID";
            this.textBoxReviewID.Size = new System.Drawing.Size(109, 29);
            this.textBoxReviewID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Review ID";
            // 
            // FormReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.ClientSize = new System.Drawing.Size(524, 579);
            this.Controls.Add(this.groupBoxNewReview);
            this.Controls.Add(this.groupBoxReview);
            this.Controls.Add(this.groupBoxProduct);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormReview";
            this.Text = "Review ID";
            this.Load += new System.EventHandler(this.FormReview_Load);
            this.groupBoxNewReview.ResumeLayout(false);
            this.groupBoxNewReview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxProduct;
        private System.Windows.Forms.GroupBox groupBoxReview;
        private System.Windows.Forms.GroupBox groupBoxNewReview;
        private System.Windows.Forms.RichTextBox richTextBoxContentNewReview;
        private System.Windows.Forms.TextBox textBoxReviewID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAdd;
    }
}