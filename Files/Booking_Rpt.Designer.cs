namespace couse_work_gad
{
    partial class Booking_Rpt
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.onewayflightTBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bookingdsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookingds = new couse_work_gad.bookingds();
            this.onewayflightTBTableAdapter = new couse_work_gad.bookingdsTableAdapters.onewayflightTBTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.onewayflightTBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingdsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingds)).BeginInit();
            this.SuspendLayout();
            // 
            // onewayflightTBBindingSource
            // 
            this.onewayflightTBBindingSource.DataMember = "onewayflightTB";
            this.onewayflightTBBindingSource.DataSource = this.bookingdsBindingSource;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.onewayflightTBBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "couse_work_gad.booking_report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1186, 796);
            this.reportViewer1.TabIndex = 0;
            // 
            // bookingdsBindingSource
            // 
            this.bookingdsBindingSource.DataSource = this.bookingds;
            this.bookingdsBindingSource.Position = 0;
            // 
            // bookingds
            // 
            this.bookingds.DataSetName = "bookingds";
            this.bookingds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // onewayflightTBTableAdapter
            // 
            this.onewayflightTBTableAdapter.ClearBeforeFill = true;
            // 
            // Booking_Rpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 796);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Booking_Rpt";
            this.Text = "Booking_Rpt";
            this.Load += new System.EventHandler(this.Booking_Rpt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.onewayflightTBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingdsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private bookingds bookingds;
        private System.Windows.Forms.BindingSource bookingdsBindingSource;
        private System.Windows.Forms.BindingSource onewayflightTBBindingSource;
        private bookingdsTableAdapters.onewayflightTBTableAdapter onewayflightTBTableAdapter;
    }
}