namespace MWPManager
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lstFiles = new System.Windows.Forms.ListView();
            this.colHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgIcons = new System.Windows.Forms.ImageList(this.components);
            this.picPhoneFrame = new System.Windows.Forms.PictureBox();
            this.tvFolders = new System.Windows.Forms.TreeView();
            this.picWP = new Cyotek.Windows.Forms.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoneFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // lstFiles
            // 
            this.lstFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeader});
            this.lstFiles.FullRowSelect = true;
            this.lstFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstFiles.HideSelection = false;
            this.lstFiles.Location = new System.Drawing.Point(12, 327);
            this.lstFiles.MultiSelect = false;
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(439, 243);
            this.lstFiles.SmallImageList = this.imgIcons;
            this.lstFiles.TabIndex = 0;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.View = System.Windows.Forms.View.Details;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            // 
            // colHeader
            // 
            this.colHeader.Width = 100;
            // 
            // imgIcons
            // 
            this.imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcons.ImageStream")));
            this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcons.Images.SetKeyName(0, "HardDrive");
            this.imgIcons.Images.SetKeyName(1, "FolderClosed");
            this.imgIcons.Images.SetKeyName(2, "FolderOpened");
            this.imgIcons.Images.SetKeyName(3, "ImageFile");
            // 
            // picPhoneFrame
            // 
            this.picPhoneFrame.Image = ((System.Drawing.Image)(resources.GetObject("picPhoneFrame.Image")));
            this.picPhoneFrame.Location = new System.Drawing.Point(457, 12);
            this.picPhoneFrame.Name = "picPhoneFrame";
            this.picPhoneFrame.Size = new System.Drawing.Size(338, 607);
            this.picPhoneFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoneFrame.TabIndex = 1;
            this.picPhoneFrame.TabStop = false;
            // 
            // tvFolders
            // 
            this.tvFolders.ImageIndex = 0;
            this.tvFolders.ImageList = this.imgIcons;
            this.tvFolders.Location = new System.Drawing.Point(12, 12);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.SelectedImageIndex = 0;
            this.tvFolders.Size = new System.Drawing.Size(439, 309);
            this.tvFolders.TabIndex = 2;
            this.tvFolders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFolders_NodeMouseClick);
            // 
            // picWP
            // 
            this.picWP.Location = new System.Drawing.Point(498, 73);
            this.picWP.Name = "picWP";
            this.picWP.Size = new System.Drawing.Size(263, 445);
            this.picWP.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 715);
            this.Controls.Add(this.picWP);
            this.Controls.Add(this.tvFolders);
            this.Controls.Add(this.picPhoneFrame);
            this.Controls.Add(this.lstFiles);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobile Wallpaper Manager";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoneFrame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstFiles;
        private System.Windows.Forms.PictureBox picPhoneFrame;
        private System.Windows.Forms.TreeView tvFolders;
        private System.Windows.Forms.ImageList imgIcons;
        private System.Windows.Forms.ColumnHeader colHeader;
        private Cyotek.Windows.Forms.ImageBox picWP;
    }
}

